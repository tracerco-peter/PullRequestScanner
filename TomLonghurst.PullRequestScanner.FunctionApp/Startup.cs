using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TomLonghurst.PullRequestScanner.AzureDevOps.Extensions;
using TomLonghurst.PullRequestScanner.AzureDevOps.Options;
using TomLonghurst.PullRequestScanner.Extensions;
using TomLonghurst.PullRequestScanner.FunctionApp;

[assembly: WebJobsStartup(typeof(Startup))]

namespace TomLonghurst.PullRequestScanner.FunctionApp
{
    public sealed class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services
                .AddPullRequestScanner()
                .AddAzureDevOps(new AzureDevOpsOptions
                {
                    OrganizationSlug = configuration.GetValue<string>("OrganizationSlug"),
                    ProjectSlug = configuration.GetValue<string>("ProjectSlug"),
                    PersonalAccessToken = configuration.GetValue<string>("PersonalAccessToken")
                });
        }
    }
}
