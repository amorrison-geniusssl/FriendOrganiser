namespace FriendOrganiser.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasework : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Friend", "PhoneNumberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Friend", "PhoneNumberId", c => c.Int());
        }
    }
}
