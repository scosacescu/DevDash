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

namespace DevDash.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        GitHubAPI gitHubAPI = new GitHubAPI();
        TrelloAPI trelloApi = new TrelloAPI();

        public AuthenticationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.GithubAuthenticated && user.TrelloAuthenticated)
            {
                var trelloToken = user.TrelloKey;
                HttpContext.Session.SetString("TrelloToken", trelloToken);
                var githubCode = user.GithubKey;
                OauthToken oauthToken = await gitHubAPI.Authorize(githubCode, "");
                HttpContext.Session.SetString("GithubToken", oauthToken.ToString());
                return RedirectToAction("Index", "ApplicationHomeController");
            }
            else
            {
                string githubAuthUrl = gitHubAPI.GitHubAuthURL();
                string trelloAuthUrl = trelloApi.GetTrelloAuthUrl();
                AuthorizationViewModel vm = new AuthorizationViewModel
                {
                    GithubAuthURL = githubAuthUrl,
                    TrelloAuthURL = trelloAuthUrl,
                    githubAuthorized = user.GithubAuthenticated,
                    trelloAuthorized = user.TrelloAuthenticated

                };
                return View(vm);
            }
        }

        public async Task<IActionResult> AuthorizeGithub(string code, string state)
        {
            var user = await _userManager.GetUserAsync(User);
            OauthToken token = await gitHubAPI.Authorize(code, state);
            HttpContext.Session.SetString("GithubToken", token.ToString());
            user.GithubKey = code;
            user.GithubAuthenticated = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AuthorizeTrello(string token)
        {
            var user = await _userManager.GetUserAsync(User);
            HttpContext.Session.SetString("TrelloToken", token);
            user.TrelloKey = token;
            user.TrelloAuthenticated = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

    }
}
