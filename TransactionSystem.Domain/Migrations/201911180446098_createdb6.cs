namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "DemandId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Replies", "DemandId");
            AddForeignKey("dbo.Replies", "DemandId", "dbo.Demands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "DemandId", "dbo.Demands");
            DropIndex("dbo.Replies", new[] { "DemandId" });
            DropColumn("dbo.Replies", "DemandId");
        }
    }
}
