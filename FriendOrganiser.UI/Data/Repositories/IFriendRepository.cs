using System.Collections.Generic;
using FriendOrganiser.Model;

namespace FriendOrganiser.UI.Data.Repositories
{

    public interface IFriendRepository : IGenericRepository<Friend>
    {  
        void RemovePhoneNumber(FriendPhoneNumber model);
    }
}