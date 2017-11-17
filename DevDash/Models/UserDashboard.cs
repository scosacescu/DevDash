using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models
{
    public class UserDashboard
    {
        public Guid DashboardID { get; set; }
        public Guid UserID { get; set; }
        public string RepoID { get; set; }
        public string BoardID { get; set; }
        public string DashboardName { get; set; }
    }
}
