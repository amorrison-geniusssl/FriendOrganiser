using FriendOrganiser.Model;
using FriendOrganiser.UI.Data;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {

        private IFriendDataService _dataService;

        public FriendDetailViewModel(IFriendDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await _dataService.GetByIdAsync(friendId);
        }

        private Friend _friend;

        public Friend Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }
    }
}
