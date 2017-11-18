using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Services
{
    public interface IGitHubAPI
    {
        string GitHubAuthURL(); 
        Task<OauthToken> Authorize(string code, string state); 
        Task<IReadOnlyList<Issue>> GetIssuesAsync(string accessToken, long repoId); 
        Task<IReadOnlyList<Repository>> getRepositoriesAsync(string accessToken); 
    }
}
