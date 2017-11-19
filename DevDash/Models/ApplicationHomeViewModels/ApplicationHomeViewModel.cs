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
        public IEnumerable<GitHub> GithubRepos { get; set; }

        [Required]
        public IEnumerable<Trello> TrelloBoard { get; set; }

        [Required]
        public IEnumerable<Dashboard> UserDashboards { get; set; }
    }
}
