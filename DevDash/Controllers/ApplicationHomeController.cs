using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevDash.Data;
using DevDash.Models;
using Microsoft.AspNetCore.Identity;
using DevDash.Services;
using Microsoft.Extensions.Configuration;
using DevDash.Models.AuthorizationViewModels;

namespace DevDash.Controllers
{
    public class ApplicationHomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        GitHubAPI gitHubAPI;
        TrelloAPI trelloApi;


        public ApplicationHomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration Configuration)
        {
            gitHubAPI = new GitHubAPI(Configuration);
            trelloApi = new TrelloAPI(Configuration);
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDashboard(CreateDashboardViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid guid = Guid.NewGuid();
                var user = await _userManager.GetUserAsync(User);
                var dashboard = new Dashboard
                {
                    DashboardId = guid,
                    DashboardName = model.DashboardName,
                    RepoId = model.RepoId,
                    BoardId = model.BoardId,
                    UserId = user.Id
                };

                _context.Add(dashboard);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboards", new { id = guid.ToString() });
            }
            return View(model);
        }

    }
}
