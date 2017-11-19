using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevDash.Models
{
    public partial class Dashboard
    {
        public string UserId { get; set; }
        public long RepoId { get; set; }
        public string BoardId { get; set; }
        public string DashboardName { get; set; }
        [Key]
        public Guid DashboardId { get; set; }

        public GitHub GitHub { get; set; }
        public Trello Trello { get; set; }
        public ApplicationUser User { get; set; }
    }
}
