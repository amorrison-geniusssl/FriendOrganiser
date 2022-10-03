using FriendOrganiser.DataAccess;
using FriendOrganiser.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.Data.Repositories
{
    public class ProgrammingLanguageRepository
    : GenericRepository<ProgrammingLanguage, FriendOrganiserDbContext>,
      IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(FriendOrganiserDbContext context)
          : base(context)
        {
        }

        public async Task<bool> IsReferencedByFriendAsync(int programmingLanguageId)
        {
            return await Context.Friends.AsNoTracking()
              .AnyAsync(f => f.FavoriteLanguageId == programmingLanguageId);
        }
    }
}
