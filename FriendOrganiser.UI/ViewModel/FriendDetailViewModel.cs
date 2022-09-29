using FriendOrganiser.Model;
using FriendOrganiser.UI.Data;
using FriendOrganiser.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System;
using System.Windows.Input;
using Prism.Commands;
using FriendOrganiser.UI.Wrapper;
using FriendOrganiser.UI.Data.Repositories;
using FriendOrganiser.UI.View.Services;

namespace FriendOrganiser.UI.ViewModel
{
  public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
  {
    private IFriendRepository _friendRepository;
    private IEventAggregator _eventAggregator;
    private FriendWrapper _friend;
    private bool _hasChanges;
    private IMessageDialogService _messageDialogService;

    public FriendDetailViewModel(IFriendRepository friendRepository,
      IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService)
    {
      _friendRepository = friendRepository;
      _eventAggregator = eventAggregator;
      _messageDialogService = messageDialogService;

      SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
      DeleteCommand = new DelegateCommand(OnDeleteExecute);
    }

    public async Task LoadAsync(int? friendId)
    {
      var friend = friendId.HasValue
        ? await _friendRepository.GetByIdAsync(friendId.Value)
        : CreateNewFriend();

      Friend = new FriendWrapper(friend);
      Friend.PropertyChanged += (s, e) =>
        {
          if(!HasChanges)
          {
            HasChanges = _friendRepository.HasChanges();
          }
          if (e.PropertyName == nameof(Friend.HasErrors))
          {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
          }
        };
      ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
      if(Friend.Id==0)
      {
        // Little trick to trigger the validation
        Friend.FirstName = "";
      }
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

    public bool HasChanges
    {
      get { return _hasChanges; }
      set
      {
        if (_hasChanges != value)
        {
          _hasChanges = value;
          OnPropertyChanged();
          ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }
      }
    }

    public ICommand SaveCommand { get; }

    public ICommand DeleteCommand { get; }

    private async void OnSaveExecute()
    {
      await _friendRepository.SaveAsync();
      HasChanges = _friendRepository.HasChanges();
      _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
        new AfterFriendSavedEventArgs
        {
          Id = Friend.Id,
          DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
        });
    }

    private bool OnSaveCanExecute()
    {
      return Friend != null && !Friend.HasErrors && HasChanges;
    }

    private async void OnDeleteExecute()
    {
      var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the friend {Friend.FirstName} {Friend.LastName}?",
        "Question");
      if (result == MessageDialogResult.OK)
      {
        _friendRepository.Remove(Friend.Model);
        await _friendRepository.SaveAsync();
        _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Publish(Friend.Id);
      }
    }

    private Friend CreateNewFriend()
    {
      var friend = new Friend();
      _friendRepository.Add(friend);
      return friend;
    }
  }
}
