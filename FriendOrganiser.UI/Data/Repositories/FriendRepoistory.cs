using FriendOrganiser.DataAccess;
using FriendOrganiser.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private FriendOrganiserDbContext _context;

        public FriendRepository(FriendOrganiserDbContext context)
        {
            _context = context;
        }
        public async Task<Friend> GetByIdAsync(int friendId)
        {
            return await _context.Friends.SingleAsync(f => f.Id == friendId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

