using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TomLonghurst.PullRequestScanner.Services;

namespace TomLonghurst.PullRequestScanner.FunctionApp
{
    public class MorningTrigger
    {
        private readonly IPullRequestScanner _pullRequestScanner;

        public MorningTrigger(IPullRequestScanner pullRequestScanner)
        {
            _pullRequestScanner = pullRequestScanner;
        }

        [FunctionName("MorningTrigger")]
        public async Task RunAsync([TimerTrigger("0 0 8 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            await _pullRequestScanner.ExecutePluginsAsync();
        }
    }
}
