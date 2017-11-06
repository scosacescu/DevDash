using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace DevDash.Controllers
{
    [Produces("application/json")]
    [Route("api/GitHub")]
    public class GitHubController : Controller
    {
        GitHubClient GitHubClient = new GitHubClient(new ProductHeaderValue("DevDash")); 
    }
}