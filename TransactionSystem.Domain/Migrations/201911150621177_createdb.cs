namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DemandId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        MinPrice = c.Single(nullable: false),
                        MaxPrice = c.Single(nullable: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreteTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Demands", t => t.DemandId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.DemandId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 40, unicode: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreteTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(nullable: false, maxLength: 20, unicode: false),
                        UserName = c.String(maxLength: 16, unicode: false),
                        ImagePath = c.String(maxLength: 300, unicode: false),
                        UesrType = c.Int(nullable: false),
                        TelphoneNumber = c.Int(nullable: false),
                        Address = c.String(maxLength: 8000, unicode: false),
                        RealName = c.String(maxLength: 10, unicode: false),
                        CompanyName = c.String(maxLength: 50, unicode: false),
                        CreteTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DemandId = c.Guid(nullable: false),
                        CommentId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        OrderState = c.Int(nullable: false),
                        CreteTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .ForeignKey("dbo.Demands", t => t.DemandId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.DemandId)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "DemandId", "dbo.Demands");
            DropForeignKey("dbo.Orders", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "DemandId", "dbo.Demands");
            DropForeignKey("dbo.Demands", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "CommentId" });
            DropIndex("dbo.Orders", new[] { "DemandId" });
            DropIndex("dbo.Demands", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "DemandId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Demands");
            DropTable("dbo.Comments");
        }
    }
}
