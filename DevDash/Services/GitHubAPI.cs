using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevDash.Services
{
    public class GitHubAPI: IGitHubAPI
    {
        public GitHubAPI(IConfiguration configuration)
        {
            clientId = configuration["Keys:GitHubClientId"];
            clientSecret = configuration["Keys:GitHubClientSecret"];
        }

        GitHubClient client = new GitHubClient(new ProductHeaderValue("DevDash"));
        private string clientId;
        private string clientSecret;

        public string GitHubAuthURL()
        {
            var request = new OauthLoginRequest(clientId)
            {
                Scopes = { "user", "repos" },
            };
            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);

            return oauthLoginUrl.ToString();
        }

        public async Task<OauthToken> Authorize(string code, string state)
        {
            OauthToken token = new OauthToken();

            if (!string.IsNullOrEmpty(code))
            {
                token = await client.Oauth.CreateAccessToken(
                    new OauthTokenRequest(clientId, clientSecret, code));
            }

            return token;

        }

        public async Task<IReadOnlyList<Issue>> GetIssuesAsync(string accessToken, long repoId)
        {

            if(accessToken != null)
            {
                client.Credentials = new Credentials(accessToken);
            }
            try
            {
                var issues = await client.Issue.GetAllForRepository(repoId);
                return issues;
            } catch(AuthorizationException authException)
            {
                throw authException;
            }
        }

        public async Task<IReadOnlyList<Repository>> getRepositoriesAsync(string accessToken)
        {
            if (accessToken != null)
            {
                client.Credentials = new Credentials(accessToken);
            }
            try
            {
                var repositories = await client.Repository.GetAllForCurrent();
                return repositories;
            }
            catch (AuthorizationException authException)
            {
                throw authException;
            }

        }
    }
}
