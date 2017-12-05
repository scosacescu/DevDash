using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrelloNet;

namespace DevDash.Models.DashboardViewModels
{
    public class TrelloViewModel
    {
        [Required]
        public string BoardName { get; set; }

        [Required]
        public IEnumerable<List> TrelloLists { get; set; }

        [Required]
        public IEnumerable<Card> TrelloCards { get; set; }

    }
}
