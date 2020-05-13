using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class CategoryListingViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }
    }

    public class CategoryViewModels : PageViewModel
    {
        public List<Category> AllCategories { get; set; }

    }

    public class CategoryDetailViewModel : PageViewModel
    {
        public Category Category { get; set; }
    }
    public class CreateCategoryViewModel : PageViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Auction> Auctions { get; set; }
    }
    public class FeedbackViewModel : PageViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        
        public List<Feedback> feedback { get; set; }
    }
}