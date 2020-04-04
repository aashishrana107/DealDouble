using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class AuctionsService
    {
        public List<Auction> GetAuction()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.ToList();
        }

        public List<Auction> SearchAuction(int? categoryID, string searchTerm, int? pageNo,int pageSize)
        {
            DealDoubleContext context = new DealDoubleContext();
            var auction = context.Auctions.AsQueryable();           //
            if (categoryID.HasValue && categoryID.Value>0)
            {
               auction = auction.Where(x => x.CategoryID == categoryID.Value);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                auction = auction.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }
            pageNo = pageNo.HasValue ? pageNo.Value : 1;
            var skipCount = (pageNo.Value- 1) * pageSize;
            return auction.OrderByDescending(x=>x.CategoryID).Skip(skipCount).Take(pageSize).ToList();
            
        }
        public List<Auction> GetpromotedAuctions()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.Take(4).ToList();
        }
        public Auction GetAuctionByID(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.Find(ID);
            
        }
        public void SaveAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Auctions.Add(auction);
            context.SaveChanges();
        }
        public void UpdateAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();
            var exitingAuction = context.Auctions.Find(auction.ID);
            context.AuctionPictures.RemoveRange(exitingAuction.AuctionPictures);
            context.Entry(exitingAuction).CurrentValues.SetValues(auction);
            context.AuctionPictures.AddRange(auction.AuctionPictures);
            context.SaveChanges();
        }
        public void DeleteAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
