﻿using FriendOrganiser.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using FriendOrganiser.UI.Wrapper;
using FriendOrganiser.UI.Data.Repositories;

namespace FriendOrganiser.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendRepository _friendRepository;
        private IEventAggregator _eventAggregator;
        private FriendWrapper _friend;

        public FriendDetailViewModel(IFriendRepository friendRepository,
          IEventAggregator eventAggregator)
        {
            _friendRepository = friendRepository;
            _eventAggregator = eventAggregator;
            

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadAsync(int friendId)
        {
            var friend = await _friendRepository.GetByIdAsync(friendId);

            Friend = new FriendWrapper(friend);
            Friend.PropertyChanged += (s, e) =>
              {
                  if (e.PropertyName == nameof(Friend.HasErrors))
                  {
                      ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                  }
              };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await _friendRepository.SaveAsync();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
              new AfterFriendSavedEventArgs
              {
                  Id = Friend.Id,
                  DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
              });
        }

        private bool OnSaveCanExecute()
        {
            // TODO: Check in addition if friend has changes
            return Friend != null && !Friend.HasErrors;
        }


    }
}