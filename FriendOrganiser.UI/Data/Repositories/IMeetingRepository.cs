using System.Threading.Tasks;
using FriendOrganiser.Model;
using System.Collections.Generic;

namespace FriendOrganiser.UI.Data.Repositories
{
  public interface IMeetingRepository : IGenericRepository<Meeting>
  {
    Task<List<Friend>> GetAllFriendsAsync();
    Task ReloadFriendAsync(int friendId);
  }
}