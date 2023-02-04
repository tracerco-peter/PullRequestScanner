using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record VotedFor(
    [property: JsonPropertyName("vote")] int Vote,
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("uniqueName")] string UniqueName
);