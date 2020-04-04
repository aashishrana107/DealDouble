using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class AuctionListingViewModel:PageViewModel
    {
        public List<Auction> Auctions { get; set; }
        public int? CategoryID { get; set; }
        public int? PageNo { get; set; }
        public string SearchTerm { get; set; }
       
        public List<Category> Categories { get; set; }
    }

    public class AuctionViewModels : PageViewModel
    {
        public List<Auction> AllAuction { get; set; }
        public List<Auction> PromotedAuction { get; set; }

    }

    public class AuctionDetailViewModel : PageViewModel
    {
        public Auction Auction { get; set; }
    }
    public class CreateAuctionViewModel : PageViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Minimum length should be 10 characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length should be 15 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(100, 1000000, ErrorMessage = "Amount between 100,1000000.")]
        public decimal ActualAmount { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
        public string AuctionPictures { get; set; }
        public List<Category> Categories { get; set; }
        public List<AuctionPicture> AuctionPicturesList { get; set; }
    }


}