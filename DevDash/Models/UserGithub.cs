using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models
{
    public class UserGithub
    {
        public Guid UserID { get; set; }
        public string RepoID { get; set; }
        public string RepoName { get; set; }
        public string IssuesURL { get; set; }
    }
}
