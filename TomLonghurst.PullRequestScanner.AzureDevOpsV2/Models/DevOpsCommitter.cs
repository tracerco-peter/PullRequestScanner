using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsCommitter(
    [property: JsonPropertyName("date")] DateTime Date,
    [property: JsonPropertyName("name")] string Name
);