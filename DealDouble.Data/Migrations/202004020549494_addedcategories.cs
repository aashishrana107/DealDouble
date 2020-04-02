namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Auctions", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Auctions", "CategoryID");
            AddForeignKey("dbo.Auctions", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Auctions", new[] { "CategoryID" });
            DropColumn("dbo.Auctions", "CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
