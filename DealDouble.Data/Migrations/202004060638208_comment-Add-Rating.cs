namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentAddRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Rating");
        }
    }
}
