using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models.ApplicationHomeViewModels
{
    public class ApplicationHomeViewModel
    {
        [Required]
        public SelectList GithubRepos { get; set; }

        [Required]
        public SelectList TrelloBoard { get; set; }

        [Required]
        public IEnumerable<Dashboard> UserDashboards { get; set; }
    }
}
