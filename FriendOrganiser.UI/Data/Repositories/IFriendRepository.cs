using System.Collections.Generic;
using FriendOrganiser.Model;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.Data.Repositories
{
    public interface IFriendRepository
    {
        Task<Friend> GetByIdAsync(int friendId);
        Task SaveAsync();
        bool HasChanges();
    }
}