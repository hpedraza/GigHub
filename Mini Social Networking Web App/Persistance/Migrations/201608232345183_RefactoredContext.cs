namespace Mini_Social_Networking_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredContext : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FolloweeId", "FollowerId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
        }
    }
}
