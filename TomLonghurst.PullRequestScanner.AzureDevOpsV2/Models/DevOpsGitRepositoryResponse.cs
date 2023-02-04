using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsGitRepositoryResponse(
        [property: JsonPropertyName("value")] IReadOnlyList<AzureDevOpsGitRepository> Repositories,
        [property: JsonPropertyName("count")] int Count
    ) : IHasCount;