using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;
using TomLonghurst.PullRequestScanner.Models;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Mappers;

internal interface IAzureDevOpsMapper
{
    PullRequest ToPullRequestModel(AzureDevOpsPullRequestContext pullRequestContext);
}