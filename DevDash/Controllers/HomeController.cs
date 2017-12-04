using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevDash.Models;
using Microsoft.AspNetCore.Identity;

namespace DevDash.Controllers
{
    public class HomeController : Controller
    {

        private UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "ApplicationHome");
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Dashboard()
        {
            ViewData["Message"] = "Your dashboard page.";
            return View();
        }

        public IActionResult AppHome()
        {
            ViewData["Message"] = "Your landing page.";
            return View();
        }
    }
}
