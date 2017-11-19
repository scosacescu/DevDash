using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevDash.Models
{
    public partial class GitHub
    {
        public GitHub()
        {
            Dashboard = new HashSet<Dashboard>();
        }

        public string UserId { get; set; }
        public long RepoId { get; set; }
        [Key]
        public string RepoName { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Dashboard> Dashboard { get; set; }
    }
}
