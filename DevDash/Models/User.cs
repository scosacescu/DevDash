using System;
using System.Collections.Generic;

namespace DevDash.Models
{
    public partial class User
    {
        public User()
        {
            Dashboard = new HashSet<Dashboard>();
            GitHub = new HashSet<GitHub>();
            Trello = new HashSet<Trello>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string GithubKey { get; set; }
        public string TrelloKey { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }

        public ICollection<Dashboard> Dashboard { get; set; }
        public ICollection<GitHub> GitHub { get; set; }
        public ICollection<Trello> Trello { get; set; }
    }
}
