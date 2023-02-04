using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsPullRequestThreadPropertyValue(
    [property: JsonPropertyName("$value")] string? Value
);