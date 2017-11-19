using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DevDash.Models
{
    public partial class User: IdentityUser
    {
        public User()
        {
            Dashboard = new HashSet<Dashboard>();
            GitHub = new HashSet<GitHub>();
            Trello = new HashSet<Trello>();
        }

        public string UserId { get; set; }
        public override string UserName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string GithubKey { get; set; }
        public string TrelloKey { get; set; }
        public override string Email { get; set; }
        public byte[] Password { get; set; }

        public ICollection<Dashboard> Dashboard { get; set; }
        public ICollection<GitHub> GitHub { get; set; }
        public ICollection<Trello> Trello { get; set; }
    }
}
