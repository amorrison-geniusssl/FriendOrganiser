using FriendOrganiser.Model;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.Data.Repositories
{
    public interface IProgrammingLanguageRepository
      : IGenericRepository<ProgrammingLanguage>
    {
        Task<bool> IsReferencedByFriendAsync(int programmingLanguageId);
    }
}
