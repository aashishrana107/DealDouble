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
            context.Entry(auction).State =System.Data.Entity.EntityState.Modified;
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
