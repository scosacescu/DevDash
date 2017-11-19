using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DevDash.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Dashboard = new HashSet<Dashboard>();
            GitHub = new HashSet<GitHub>();
            Trello = new HashSet<Trello>();
        }

        //TODO: Should include access to the API keys and the user profile information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GithubKey { get; set; }
        public string TrelloKey { get; set; }
        public bool GithubAuthenticated { get; set; }
        public bool TrelloAuthenticated { get; set; }


        public ICollection<Dashboard> Dashboard { get; set; }
        public ICollection<GitHub> GitHub { get; set; }
        public ICollection<Trello> Trello { get; set; }
    }
}
