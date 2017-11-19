using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDash.Models.ApplicationHomeViewModels
{
    public class CombinedViewModel
    {
        public ApplicationHomeViewModel ApplicationHomeViewModel { get; set; }
        public CreateDashboardViewModel CreateDashboardViewModel { get; set; }
    }
}
