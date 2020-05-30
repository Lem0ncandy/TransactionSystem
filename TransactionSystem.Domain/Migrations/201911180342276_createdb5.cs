namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 80, unicode: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreteTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CommentId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        CreteTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.FeedBacks", "UserId", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "UserId" });
            DropIndex("dbo.Replies", new[] { "CommentId" });
            DropIndex("dbo.FeedBacks", new[] { "UserId" });
            DropTable("dbo.Replies");
            DropTable("dbo.FeedBacks");
        }
    }
}
