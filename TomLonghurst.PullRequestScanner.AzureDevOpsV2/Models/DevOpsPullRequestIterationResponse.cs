using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsPullRequestIterationResponse(
    [property: JsonPropertyName("value")] IReadOnlyList<AzureDevOpsPullRequestIteration> Value,
    [property: JsonPropertyName("count")] int Count
) : IHasCount;