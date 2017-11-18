﻿using System;
using System.Collections.Generic;

namespace DevDash.Models
{
    public partial class Dashboard
    {
        public Guid UserId { get; set; }
        public string RepoId { get; set; }
        public string BoardId { get; set; }
        public string DashboardName { get; set; }
        public Guid DashboardId { get; set; }

        public GitHub GitHub { get; set; }
        public Trello Trello { get; set; }
        public User User { get; set; }
    }
}
