using DealDouble.Data;
using DealDouble.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class BidsService
    {
        public bool AddBid(Bid bid)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Bids.Add(bid);
            return context.SaveChanges() > 0;
        }

        public List<string> GetBidByID(int ID,string UserID)
        {
            DealDoubleContext context = new DealDoubleContext();
            var AuctionID = context.Bids.Where(x => x.ID == ID).Select(x => x.AuctionID).FirstOrDefault();
            var title = context.Bids.Where(x => x.ID==ID).Select(x=>x.Auction.Title).FirstOrDefault();
            var Amount = context.Bids.Where(x => x.ID == ID).Select(x => x.Auction.ActualAmount).FirstOrDefault();
            // string a = Amount.ToString();
            
            var BigId = context.Bids.Where(x => x.AuctionID == AuctionID && x.UserID==UserID).OrderByDescending(x => x.ID).FirstOrDefault();
            var BidAmount1 = Amount + context.Bids.Where(x=>x.AuctionID==AuctionID && x.ID>=ID).Sum(x=>x.BidAmount);
            string a = BidAmount1.ToString();
            var totalBidAmount = Amount + context.Bids.Where(x => x.AuctionID == AuctionID).Sum(x => x.BidAmount);
            string b = totalBidAmount.ToString();
            var EndingTime = context.Bids.Where(x => x.ID == ID).Select(x => x.Auction.EndingTime).FirstOrDefault();
            string c = EndingTime.ToString();
            List<string> TitleAmountList = new List<string>();
            
            TitleAmountList.Add(title);
            TitleAmountList.Add(a);
            TitleAmountList.Add(b);
            TitleAmountList.Add(c);
            return TitleAmountList;
        }

        public int GetBidByUserID(string UserID,int AuctionIDByUser)
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Bids.Where(x=>x.UserID==UserID && x.AuctionID == AuctionIDByUser).Select(x=>x.ID).FirstOrDefault();

        }
        public List<int> NoOfBids(string UserID)
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Bids.Where(x=>x.UserID == UserID).Select(x=>x.AuctionID ).Distinct().ToList();
        }
    }
}
