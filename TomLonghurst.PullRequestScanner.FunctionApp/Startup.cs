using System;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TomLonghurst.PullRequestScanner.AzureDevOps.Extensions;
using TomLonghurst.PullRequestScanner.AzureDevOps.Options;
using TomLonghurst.PullRequestScanner.Extensions;
using TomLonghurst.PullRequestScanner.FunctionApp;
using TomLonghurst.PullRequestScanner.Plugins.MicrosoftTeams.WebHook.Extensions;
using TomLonghurst.PullRequestScanner.Plugins.MicrosoftTeams.WebHook.Options;

[assembly: WebJobsStartup(typeof(Startup))]

namespace TomLonghurst.PullRequestScanner.FunctionApp
{
    public sealed class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            var projects = configuration.GetValue<string>("Projects").Split(';');

            var scanner = builder.Services
                .AddPullRequestScanner()
                .AddMicrosoftTeamsWebHookPublisher(new MicrosoftTeamsOptions
                    {
                        WebHookUri = configuration.GetValue<Uri>("MicrosoftTeamsWebhookUri")
                    }
                );

            foreach (string project in projects)
            {
                scanner.AddAzureDevOps(new AzureDevOpsOptions
                {
                    OrganizationSlug = configuration.GetValue<string>("OrganizationSlug"),
                    ProjectSlug = project,
                    PersonalAccessToken = configuration.GetValue<string>("PersonalAccessToken")
                });
            }

 
        }
    }
}
