using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsPullRequestThreadResponse(
        [property: JsonPropertyName("value")] IReadOnlyList<AzureDevOpsPullRequestThread> Threads,
        [property: JsonPropertyName("count")] int Count
    ) : IHasCount;