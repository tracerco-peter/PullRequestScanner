using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Services;

internal interface IAzureDevOpsPullRequestService
{
    Task<IReadOnlyList<AzureDevOpsPullRequestContext>> GetPullRequestsForRepository(AzureDevOpsGitRepository githubGitRepository);
}