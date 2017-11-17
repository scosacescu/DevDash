using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models
{
    public class UserTrello
    {
        public Guid UserID { get; set; }
        public string BoardID { get; set; }
        public string BoardName { get; set; }
        public string BackgroundImageURL { get; set; }
    }
}
