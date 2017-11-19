using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models.AuthorizationViewModels
{
    public class AuthorizationViewModel
    {
        [Required]
        public string GithubAuthURL { get; set; }

        [Required]
        public string TrelloAuthURL { get; set; }
        
        [Required]
        public bool GithubAuthorized { get; set; }

        [Required]
        public bool TrelloAuthorized { get; set; }
    }
}
