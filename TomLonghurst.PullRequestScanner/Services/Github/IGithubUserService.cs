﻿using TomLonghurst.PullRequestScanner.Models.Github;

namespace TomLonghurst.PullRequestScanner.Services.Github;

internal interface IGithubUserService
{
    List<GithubMember> GetTeamMembers();
}