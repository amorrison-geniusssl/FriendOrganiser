namespace FriendOrganiser.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefriend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friend", "PhoneNumberId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friend", "PhoneNumberId");
        }
    }
}
