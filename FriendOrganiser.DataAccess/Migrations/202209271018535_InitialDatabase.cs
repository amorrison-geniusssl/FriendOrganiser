namespace FriendOrganiser.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Friend", newName: "Friends");
            AlterColumn("dbo.Friends", "FirstName", c => c.String());
            AlterColumn("dbo.Friends", "LastName", c => c.String());
            AlterColumn("dbo.Friends", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Friends", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Friends", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Friends", "FirstName", c => c.String(nullable: false, maxLength: 50));
            RenameTable(name: "dbo.Friends", newName: "Friend");
        }
    }
}
