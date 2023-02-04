using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsPullRequestIterationContext(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("genre")] string Genre
);