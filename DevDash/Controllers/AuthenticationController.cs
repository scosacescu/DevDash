using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevDash.Data;
using DevDash.Services;
using Octokit;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Identity;
using DevDash.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DevDash.Models.AuthorizationViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration;

namespace DevDash.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        GitHubAPI gitHubAPI;
        TrelloAPI trelloApi;

        public AuthenticationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration Configuration)
        {
            gitHubAPI = new GitHubAPI(Configuration);
            trelloApi = new TrelloAPI(Configuration);
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.GithubAuthenticated && user.TrelloAuthenticated)
            {
                HttpContext.Session.TryGetValue("GithubToken", out byte[] tokenArray);
                if (tokenArray != null)
                {
                    var trelloToken = user.TrelloKey;
                    HttpContext.Session.SetString("TrelloToken", trelloToken);
                    return RedirectToAction("Index", "ApplicationHome");
                }
                else
                {
                    return Redirect(gitHubAPI.GitHubAuthURL());
                }
            }
            else
            {
                string githubAuthUrl = gitHubAPI.GitHubAuthURL();
                string trelloAuthUrl = trelloApi.GetTrelloAuthUrl();
                AuthorizationViewModel vm = new AuthorizationViewModel
                {
                    GithubAuthURL = githubAuthUrl,
                    TrelloAuthURL = trelloAuthUrl,
                    GithubAuthorized = user.GithubAuthenticated,
                    TrelloAuthorized = user.TrelloAuthenticated

                };
                return View(vm);
            }
        }

        public async Task<IActionResult> AuthorizeGithub(string code, string state = "")
        {
            var user = await _userManager.GetUserAsync(User);
            OauthToken token = await gitHubAPI.Authorize(code, state);
            HttpContext.Session.SetString("GithubToken", token.AccessToken);
            if (!user.GithubAuthenticated)
            {
                user.GithubAuthenticated = true;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        public IActionResult AuthorizeTrelloAjax()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizeTrello()
        {
            string id = Request.Form["trelloToken"];
            var user = await _userManager.GetUserAsync(User);
            HttpContext.Session.SetString("TrelloToken", id);
            user.TrelloKey = id;
            user.TrelloAuthenticated = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

    }
}
