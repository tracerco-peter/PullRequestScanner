﻿using TomLonghurst.EnumerableAsyncProcessor.Extensions;
using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Http;
using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Models;
using TomLonghurst.PullRequestScanner.AzureDevOpsV2.Options;
using TomLonghurst.PullRequestScanner.Contracts;
using TomLonghurst.PullRequestScanner.Models;

namespace TomLonghurst.PullRequestScanner.AzureDevOpsV2.Services;

internal class AzureDevOpsTeamMembersProvider : ITeamMembersProvider
{
    private readonly AzureDevOpsHttpClient _devOpsHttpClient;
    private readonly AzureDevOpsOptions _azureDevOpsOptions;

    public AzureDevOpsTeamMembersProvider(AzureDevOpsHttpClient azureDevOpsHttpClient, AzureDevOpsOptions azureDevOpsOptions)
    {
        _devOpsHttpClient = azureDevOpsHttpClient;
        _azureDevOpsOptions = azureDevOpsOptions;
    }

    public async Task<IEnumerable<ITeamMember>> GetTeamMembers()
    {
        if (!_azureDevOpsOptions.IsEnabled)
        {
            return Array.Empty<ITeamMember>();
        }

        var teamsInProject = await _devOpsHttpClient.GetAll<AzureDevOpsTeamWrapper>(
            $"https://dev.azure.com/{_azureDevOpsOptions.OrganizationSlug}/_apis/projects/{_azureDevOpsOptions.ProjectSlug}/teams?api-version=7.1-preview.2");

        var membersResponses = await teamsInProject
            .SelectMany(x => x.Value)
            .ToAsyncProcessorBuilder()
            .SelectAsync(x => _devOpsHttpClient.GetAll<AzureDevOpsTeamMembersResponseWrapper>(
                $"https://dev.azure.com/{_azureDevOpsOptions.OrganizationSlug}/_apis/projects/{_azureDevOpsOptions.ProjectSlug}/teams/{x.Id}/members?api-version=7.1-preview.2"))
            .ProcessInParallel(50, TimeSpan.FromSeconds(5));

        return membersResponses
            .SelectMany(x => x)
            .SelectMany(x => x.Value)
            .Where(x => x.Identity.DisplayName != Constants.VstsDisplayName)
            .Where(x => !x.Identity.UniqueName.StartsWith(Constants.VstfsUniqueNamePrefix))
            .ToList();
    }
}