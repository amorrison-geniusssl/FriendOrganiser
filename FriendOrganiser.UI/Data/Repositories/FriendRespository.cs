using FriendOrganiser.DataAccess;
using FriendOrganiser.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.Data.Repositories
{
  public class FriendRespository : GenericRepository<Friend,FriendOrganiserDbContext>,
                                   IFriendRepository
  {
    public FriendRespository(FriendOrganiserDbContext context)
      :base(context)
    {
    }

    public override async Task<Friend> GetByIdAsync(int friendId)
    {
      return await Context.Friends
        .Include(f => f.PhoneNumbers)
        .SingleAsync(f => f.Id == friendId);
    }

    public async Task<bool> HasMeetingsAsync(int friendId)
    {
      return await Context.Meetings.AsNoTracking()
        .Include(m => m.Friends)
        .AnyAsync(m => m.Friends.Any(f => f.Id == friendId));
    }

    public void RemovePhoneNumber(FriendPhoneNumber model)
    {
      Context.FriendPhoneNumbers.Remove(model);
    }
  }
}
