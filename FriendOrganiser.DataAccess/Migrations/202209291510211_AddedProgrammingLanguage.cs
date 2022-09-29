namespace FriendOrganiser.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProgrammingLanguage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgrammingLanguage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Friend", "FavouriteLanguageId", c => c.Int());
            AddColumn("dbo.Friend", "FavoriteLanguage_Id", c => c.Int());
            AlterColumn("dbo.Friend", "Email", c => c.String(maxLength: 50));
            CreateIndex("dbo.Friend", "FavoriteLanguage_Id");
            AddForeignKey("dbo.Friend", "FavoriteLanguage_Id", "dbo.ProgrammingLanguage", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "FavoriteLanguage_Id", "dbo.ProgrammingLanguage");
            DropIndex("dbo.Friend", new[] { "FavoriteLanguage_Id" });
            AlterColumn("dbo.Friend", "Email", c => c.String(maxLength: 20));
            DropColumn("dbo.Friend", "FavoriteLanguage_Id");
            DropColumn("dbo.Friend", "FavouriteLanguageId");
            DropTable("dbo.ProgrammingLanguage");
        }
    }
}
