using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCategories { get; set; }
        public int TotalAuctions { get; set; }
        public int TotalBids { get; set; }
        public int TotalUsers { get; set; }
    }
}