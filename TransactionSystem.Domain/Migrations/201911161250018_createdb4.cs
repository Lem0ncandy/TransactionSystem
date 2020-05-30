namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "MinPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Comments", "MaxPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Comments", "Title", c => c.String(nullable: false, maxLength: 80, unicode: false));
            AddColumn("dbo.Demands", "Introduction", c => c.String(nullable: false, maxLength: 80, unicode: false));
            AlterColumn("dbo.Demands", "Title", c => c.String(nullable: false, maxLength: 60, unicode: false));
            DropColumn("dbo.Comments", "Price");
            DropColumn("dbo.Demands", "MinPrice");
            DropColumn("dbo.Demands", "MaxPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demands", "MaxPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Demands", "MinPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Comments", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Demands", "Title", c => c.String(nullable: false, maxLength: 40, unicode: false));
            DropColumn("dbo.Demands", "Introduction");
            DropColumn("dbo.Comments", "Title");
            DropColumn("dbo.Comments", "MaxPrice");
            DropColumn("dbo.Comments", "MinPrice");
        }
    }
}
