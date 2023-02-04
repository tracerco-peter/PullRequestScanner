using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsAuthor(
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("uniqueName")] string UniqueName
);