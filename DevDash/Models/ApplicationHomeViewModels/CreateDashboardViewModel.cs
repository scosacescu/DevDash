using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models.ApplicationHomeViewModels
{
    public class CreateDashboardViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Please select a repository from the list.")]
        [Display(Name = "Repositories")]
        public string RepoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please select a Trello Board from the list.")]
        [Display(Name = "Trello Boards")]
        public string BoardId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please provide a valid Dashboard Name.")]
        [Display(Name = "Dashboard Name")]
        public string DashboardName { get; set; }
    }
}
