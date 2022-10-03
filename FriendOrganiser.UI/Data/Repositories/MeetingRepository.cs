using System.Threading.Tasks;
using FriendOrganiser.DataAccess;
using FriendOrganiser.Model;
using System.Data.Entity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FriendOrganiser.UI.Data.Repositories
{
  public class MeetingRepository : GenericRepository<Meeting, FriendOrganiserDbContext>, 
    IMeetingRepository
  {
    public MeetingRepository(FriendOrganiserDbContext context) : base(context)
    {
    }

    public async override Task<Meeting> GetByIdAsync(int id)
    {
      return await Context.Meetings
        .Include(m => m.Friends)
        .SingleAsync(m => m.Id == id);
    }

    public async Task<List<Friend>> GetAllFriendsAsync()
    {
      return await Context.Set<Friend>()
          .ToListAsync();
    }

    public async Task ReloadFriendAsync(int friendId)
    {
      var dbEntityEntry = Context.ChangeTracker.Entries<Friend>()
        .SingleOrDefault(db => db.Entity.Id == friendId);
      if(dbEntityEntry!=null)
      {
        await dbEntityEntry.ReloadAsync();
      }
    }
  }
}
