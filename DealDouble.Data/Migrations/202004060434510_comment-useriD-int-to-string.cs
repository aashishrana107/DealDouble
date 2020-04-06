namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentuseriDinttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
        }
    }
}
