namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Demands", "MinPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Demands", "MaxPrice", c => c.Single(nullable: false));
            DropColumn("dbo.Comments", "MinPrice");
            DropColumn("dbo.Comments", "MaxPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "MaxPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Comments", "MinPrice", c => c.Single(nullable: false));
            DropColumn("dbo.Demands", "MaxPrice");
            DropColumn("dbo.Demands", "MinPrice");
            DropColumn("dbo.Comments", "Price");
        }
    }
}
