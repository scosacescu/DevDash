using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevDash.Data;
using DevDash.Models;
using DevDash.Services;

namespace DevDash.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authentication
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        public async Task<IActionResult> AuthenticateUser()
        {
            GitHubAPI gitHubAPI = new GitHubAPI();
            string authUrl = gitHubAPI.GitHubAuthURL();
            return View();
        }

    }
}
