namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demands", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demands", "IsHidden");
        }
    }
}
