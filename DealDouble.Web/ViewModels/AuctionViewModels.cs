using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class AuctionListingViewModel:PageViewModel
    {
        public List<Auction> Auctions { get; set; }
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
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string AuctionPictures { get; set; }

    }


}