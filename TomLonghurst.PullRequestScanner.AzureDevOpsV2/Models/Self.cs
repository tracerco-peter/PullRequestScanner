using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record Self(
    [property: JsonPropertyName("href")] string Href
);