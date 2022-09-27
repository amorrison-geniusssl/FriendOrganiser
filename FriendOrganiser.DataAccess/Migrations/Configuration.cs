namespace FriendOrganiser.DataAccess.Migrations
{
    using FriendOrganiser.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganiserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FriendOrganiserDbContext context)
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
