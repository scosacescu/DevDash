using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevDash.Data;
using DevDash.Models;
using DevDash.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TrelloNet;
using DevDash.Models.DashboardViewModels;

namespace DevDash.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        GitHubAPI gitHubAPI;
        TrelloAPI trelloAPI;

        public DashboardsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            gitHubAPI = new GitHubAPI(configuration);
            trelloAPI = new TrelloAPI(configuration);
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            var trelloToken = user.TrelloKey;
            HttpContext.Session.TryGetValue("GithubToken", out byte[] githubTokenByteArray);
            var githubToken = System.Text.Encoding.Default.GetString(githubTokenByteArray);

            Guid dashboardId = Guid.Parse(id);
            var dashboard = await _context.FindAsync<Dashboard>(dashboardId);
            BoardId boardId = new Models.Trello.BoardId { dashboard.BoardId };

            var issues = await gitHubAPI.GetIssuesAsync(githubToken, dashboard.RepoId);
            var lists = trelloAPI.GetUserBoardList(trelloToken, boardId);
            var cards = trelloAPI.GetBoardCards(trelloToken, boardId);

            return View(new DashboardDataViewModel
            {
                Issues = issues,
                TrelloLists = lists,
                TrelloCards = cards
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewIssue()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ModifyGithubIssue()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewTrelloCard()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ModifyTrelloCard()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTrelloCard()
        {
            return PartialView();
        }

    }
}
