using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models.DashboardViewModels
{
    public class GithubIssueViewModel
    {
        [Required]
        public IReadOnlyList<Issue> Issues { get; set; }
    }
}
