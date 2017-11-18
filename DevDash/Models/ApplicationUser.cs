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
        //TODO: Should include access to the API keys and the user profile information
        public Guid UserID { get; set; }
        public override string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GithubKey { get; set; }
        public override string Email { get; set; }
    }
}
