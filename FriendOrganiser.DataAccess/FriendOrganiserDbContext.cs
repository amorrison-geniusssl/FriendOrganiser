using FriendOrganiser.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FriendOrganiser.DataAccess
{
    public class FriendOrganiserDbContext : DbContext
    {
        public FriendOrganiserDbContext() : base("FriendOrganiserDb")
        {

        }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public DbSet<FriendPhoneNumber> FriendPhoneNumbers { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
