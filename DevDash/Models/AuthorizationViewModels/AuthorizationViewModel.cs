using System.ComponentModel.DataAnnotations;

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
