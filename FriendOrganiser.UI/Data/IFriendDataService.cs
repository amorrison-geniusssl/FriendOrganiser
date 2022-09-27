using FriendOrganiser.Model;
using System.Collections.Generic;

namespace FriendOrganiser.UI.Data
{
    public interface IFriendDataService
    {
        IEnumerable<Friend> GetAll();
    }
}