﻿using System.Text.Json.Serialization;
using TomLonghurst.PullRequestScanner.Models;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsTeamMember(
    [property: JsonPropertyName("identity")] Identity Identity,
    [property: JsonPropertyName("isTeamAdmin")] bool? IsTeamAdmin
) : ITeamMember
{
    public string DisplayName { get; } = Identity?.DisplayName;
    public string UniqueName { get; } = Identity?.UniqueName;
    public string Id { get; } = Identity?.Id;
    public string Email { get; } = Identity?.UniqueName;
    public string ImageUrl { get; }
}