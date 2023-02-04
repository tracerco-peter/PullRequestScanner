using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Http;
using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;
using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Options;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Services;

internal class AzureDevOpsGitRepositoryService : IAzureDevOpsGitRepositoryService
{
    private readonly AzureDevOpsHttpClient _githubHttpClient;
    private readonly AzureDevOpsOptions _azureDevOpsOptions;

    public AzureDevOpsGitRepositoryService(AzureDevOpsHttpClient githubHttpClient, AzureDevOpsOptions azureDevOpsOptions)
    {
        _githubHttpClient = githubHttpClient;
        _azureDevOpsOptions = azureDevOpsOptions;
    }
    
    public async Task<IEnumerable<AzureDevOpsGitRepository>> GetGitRepositories()
    {
        var gitRepositoryResponse = await _githubHttpClient.GetAll<AzureDevOpsGitRepositoryResponse>("repositories?api-version=7.1-preview.1");
        return gitRepositoryResponse.SelectMany(x => x.Repositories)
            .Where(x => !x.IsDisabled)
            .Where(x => _azureDevOpsOptions.RepositoriesToScan.Invoke(x));
    }
}