using System;
using System.Collections.Generic;

namespace DevDash.Models
{
    public partial class Trello
    {
        public Trello()
        {
            Dashboard = new HashSet<Dashboard>();
        }

        public Guid UserId { get; set; }
        public string BoardId { get; set; }
        public string BoardName { get; set; }
        public string BackgroundImageUrl { get; set; }

        public User User { get; set; }
        public ICollection<Dashboard> Dashboard { get; set; }
    }
}
