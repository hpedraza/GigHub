namespace Mini_Social_Networking_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "Type_Id", "dbo.Notifications");
            DropIndex("dbo.Notifications", new[] { "Type_Id" });
            AddColumn("dbo.Notifications", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Notifications", "Type_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "Type_Id", c => c.Int());
            DropColumn("dbo.Notifications", "Type");
            CreateIndex("dbo.Notifications", "Type_Id");
            AddForeignKey("dbo.Notifications", "Type_Id", "dbo.Notifications", "Id");
        }
    }
}
