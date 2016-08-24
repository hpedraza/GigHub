namespace Mini_Social_Networking_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFollowingsToApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
