using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealDouble.Web.ViewModels
{
    public class AuctionViewModels
    {
        public List<Auction> AllAuction { get; set; }
        public List<Auction> PromotedAuction { get; set; }
    }
}