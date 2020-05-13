using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class DemoModel
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string amount { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string prodInfo { get; set; }
        [Required]
        public string surl { get; set; }
        [Required]
        public string furl { get; set; }
        [Required]
        public string email { get; set; }
    }
}