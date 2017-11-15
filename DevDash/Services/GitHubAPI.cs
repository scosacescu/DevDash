using Octokit;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevDash.Services
{
    //TODO: Add API service for authentication
    //TODO: Get all repos for a user
    //TODO: Add service for getting API issues for a given user
    public class GitHubAPI
    {

        public async Task OAuthUser()
        {
            //TODO: These should be kept in a config file that is not checked in
            var clientId = "clientId";
            var clientSecret = "secret";
            var client = new GitHubClient(new ProductHeaderValue("DevDash"));
            var request = new OauthLoginRequest(clientId)
            {
                Scopes = { "user", "repos" },
                RedirectUri = new System.Uri(""),
            };
            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);

            var token = await client.Oauth.CreateAccessToken(request);
        }

        public async Task GetIssuesAsync()
        {
            var client = new GitHubClient(new ProductHeaderValue("DevDash"));
            //FIXME: The token should be grabbed from the database
            var tokenAuth = new Credentials("token");
            client.Credentials = tokenAuth;
        }
    }
}
