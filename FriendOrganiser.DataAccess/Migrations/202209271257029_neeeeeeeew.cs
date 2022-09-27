namespace FriendOrganiser.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neeeeeeeew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Friend", "Email", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Friend", "Email", c => c.String(maxLength: 50));
        }
    }
}
