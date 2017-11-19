using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevDash.Models
{
    public partial class Trello
    {
        public Trello()
        {
            Dashboard = new HashSet<Dashboard>();
        }

        public string UserId { get; set; }
        public string BoardId { get; set; }
        public string BoardName { get; set; }
        public string BackgroundImageUrl { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Dashboard> Dashboard { get; set; }
    }
}
