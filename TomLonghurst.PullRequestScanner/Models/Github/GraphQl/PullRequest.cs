﻿using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.Models.Github.GraphQl;

public record PullRequest(
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("reviewDecision")] string ReviewDecision,
    [property: JsonPropertyName("reviewThreads")] ReviewThreads ReviewThreads
);