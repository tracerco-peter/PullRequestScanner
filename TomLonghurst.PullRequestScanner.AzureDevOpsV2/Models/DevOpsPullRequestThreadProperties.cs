using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsPullRequestThreadProperties(
    [property: JsonPropertyName("CodeReviewThreadType")] AzureDevOpsPullRequestThreadPropertyValue? CodeReviewThreadType
);