﻿using TomLonghurst.PullRequestScanner.Models.Self;

namespace TomLonghurst.PullRequestScanner.Services;

internal interface IPullRequestScannerNotifier
{
    Task NotifyTeamsChannel(MicrosoftTeamsPublishOptions microsoftTeamsPublishOptions);
    Task NotifyTeamsChannel(IReadOnlyList<PullRequest> pullRequests, MicrosoftTeamsPublishOptions microsoftTeamsPublishOptions);
}