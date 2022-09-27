using FriendOrganiser.Model;
using System.Data.Entity.Migrations;

namespace FriendOrganiser.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganiser.DataAccess.FriendOrganiserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganiser.DataAccess.FriendOrganiserDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend { FirstName = "Thomas", LastName = "Huber" },
                new Friend { FirstName = "Urs", LastName = "Meier" },
                new Friend { FirstName = "Erkan", LastName = "Egin" },
                new Friend { FirstName = "Sara", LastName = "Huber" }
                );
        }
    }
}
