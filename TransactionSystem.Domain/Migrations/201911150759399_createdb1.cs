namespace $safeprojectname$.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "TelphoneNumber", c => c.String(maxLength: 11, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "TelphoneNumber", c => c.Int(nullable: false));
        }
    }
}
