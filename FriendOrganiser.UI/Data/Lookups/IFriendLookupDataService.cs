using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganiser.Model;

namespace FriendOrganiser.UI.Data.Lookups
{
  public interface IFriendLookupDataService
  {
    Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
  }
}