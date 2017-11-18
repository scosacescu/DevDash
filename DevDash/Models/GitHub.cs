using System;
using System.Collections.Generic;

namespace DevDash.Models
{
    public partial class GitHub
    {
        public GitHub()
        {
            Dashboard = new HashSet<Dashboard>();
        }

        public Guid UserId { get; set; }
        public string RepoId { get; set; }
        public string RepoName { get; set; }
        public string IssuesUrl { get; set; }

        public User User { get; set; }
        public ICollection<Dashboard> Dashboard { get; set; }
    }
}
