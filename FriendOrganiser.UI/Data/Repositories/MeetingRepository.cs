using FriendOrganiser.DataAccess;
using FriendOrganiser.Model;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FriendOrganiser.UI.Data.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting, FriendOrganiserDbContext>, IMeetingRepository
    {
        public MeetingRepository(FriendOrganiserDbContext context) : base(context)
        {
        }

        public override async Task<Meeting> GetByIdAsync(int id)
        {
            return await Context.Meetings.Include(m => m.Friends).SingleAsync(m => m.Id == id);
        }
    }
}
