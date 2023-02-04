using System.Text.Json.Serialization;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;

public record AzureDevOpsTeamMembersResponseWrapper(
    [property: JsonPropertyName("value")] IReadOnlyList<AzureDevOpsTeamMember> Value,
    [property: JsonPropertyName("count")] int Count
) : IHasCount;