namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterFieldsintable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "address", c => c.String());
            AddColumn("dbo.AspNetUsers", "city", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "city");
            DropColumn("dbo.AspNetUsers", "address");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
