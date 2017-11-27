using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrelloNet;

namespace DevDash.Models.DashboardViewModels
{
    public class DashboardDataViewModel
    {
        [Required]
        public IReadOnlyList<Issue> Issues { get; set; }

        [Required]
        public IEnumerable<List> TrelloLists { get; set; }
        
        [Required]
        public IEnumerable<Card> TrelloCards { get; set; }
    }
}
