using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Services;

internal interface IAzureDevOpsGitRepositoryService
{
    Task<IEnumerable<AzureDevOpsGitRepository>> GetGitRepositories();
}