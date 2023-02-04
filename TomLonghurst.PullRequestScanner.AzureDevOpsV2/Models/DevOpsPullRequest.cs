﻿using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsPullRequest(
    [property: JsonPropertyName("repository")] Repository Repository,
    [property: JsonPropertyName("pullRequestId")] int PullRequestId,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("createdBy")] CreatedBy CreatedBy,
    [property: JsonPropertyName("creationDate")] DateTime CreationDate,
    [property: JsonPropertyName("closedDate")] DateTime ClosedDate,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("commits")] IReadOnlyList<AzureDevOpsCommit> Commits,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("mergeFailureMessage")] string MergeFailureMessage,
    [property: JsonPropertyName("mergeStatus")] string MergeStatus,
    [property: JsonPropertyName("isDraft")] bool IsDraft,
    [property: JsonPropertyName("reviewers")] IReadOnlyList<Reviewer> Reviewers,
    [property: JsonPropertyName("url")] string Url
);