using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsCommit(
    [property: JsonPropertyName("committer")] AzureDevOpsCommitter Committer
    );