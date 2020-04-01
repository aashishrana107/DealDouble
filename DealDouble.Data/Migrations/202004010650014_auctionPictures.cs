namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auctionPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuctionID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.AuctionID, cascadeDelete: true)
                .Index(t => t.AuctionID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Auctions", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "Image", c => c.String());
            DropForeignKey("dbo.AuctionPictures", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionPictures", "PictureID", "dbo.Pictures");
            DropIndex("dbo.AuctionPictures", new[] { "PictureID" });
            DropIndex("dbo.AuctionPictures", new[] { "AuctionID" });
            DropTable("dbo.Pictures");
            DropTable("dbo.AuctionPictures");
        }
    }
}
