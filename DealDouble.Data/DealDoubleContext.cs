using DealDouble.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Data
{
    public class DealDoubleContext : IdentityDbContext<DealDoubleUser>
    {
        public DealDoubleContext() : base("DealDoubleConnectionString")
        {
            Database.SetInitializer<DealDoubleContext>(new DealDoubleDBInitialzer());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AuctionPicture> AuctionPictures { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


        public static DealDoubleContext Create()
        {
            return new DealDoubleContext();
        }





        //strategy

        //Createdatabase if they are not exist     //default entity use this 
        //dropcreate database if model changes  //is se har bar migration nai karna haga
        //dropcreatedatabaseAlways
    }

}