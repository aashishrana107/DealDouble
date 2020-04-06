using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class CommentViewModel
    {
        public string Text { get; set; }
        public int EntityID { get; set; }
        public int RecordID { get; set; }
    }
}