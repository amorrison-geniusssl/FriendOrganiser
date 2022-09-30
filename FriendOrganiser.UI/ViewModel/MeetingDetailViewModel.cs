﻿using FriendOrganiser.Model;
using FriendOrganiser.UI.Data.Repositories;
using FriendOrganiser.UI.View.Services;
using FriendOrganiser.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.ViewModel
{
  public class MeetingDetailViewModel : DetailViewModelBase, IMeetingDetailViewModel
  {
    private IMeetingRepository _meetingRepository;
    private MeetingWrapper _meeting;
    private IMessageDialogService _messageDialogService;

    public MeetingDetailViewModel(IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService,
      IMeetingRepository meetingRepository) : base(eventAggregator)
    {
      _meetingRepository = meetingRepository;
      _messageDialogService = messageDialogService;
    }

    public MeetingWrapper Meeting
    {
      get { return _meeting; }
      private set
      {
        _meeting = value;
        OnPropertyChanged();
      }
    }

    public override async Task LoadAsync(int? meetingId)
    {
      var meeting = meetingId.HasValue
        ? await _meetingRepository.GetByIdAsync(meetingId.Value)
        : CreateNewMeeting();

      InitializeMeeting(meeting);
    }

    protected override void OnDeleteExecute()
    {
      var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the meeting {Meeting.Title}?", "Question");
      if (result == MessageDialogResult.OK)
      {
        _meetingRepository.Remove(Meeting.Model);
        _meetingRepository.SaveAsync();
        RaiseDetailDeletedEvent(Meeting.Id);
      }
    }

    protected override bool OnSaveCanExecute()
    {
      return Meeting != null && !Meeting.HasErrors && HasChanges;
    }

    protected override async void OnSaveExecute()
    {
      await _meetingRepository.SaveAsync();
      HasChanges = _meetingRepository.HasChanges();
      RaiseDetailSavedEvent(Meeting.Id, Meeting.Title);
    }

    private Meeting CreateNewMeeting()
    {
      var meeting = new Meeting
      {
        DateFrom = DateTime.Now.Date,
        DateTo = DateTime.Now.Date
      };
      _meetingRepository.Add(meeting);
      return meeting;
    }

    private void InitializeMeeting(Meeting meeting)
    {
      Meeting = new MeetingWrapper(meeting);
      Meeting.PropertyChanged += (s, e) =>
      {
        if (!HasChanges)
        {
          HasChanges = _meetingRepository.HasChanges();
        }

        if (e.PropertyName == nameof(Meeting.HasErrors))
        {
          ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }
      };
      ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

      if(Meeting.Id == 0)
      {
        // Little trick to trigger the validation
        Meeting.Title = "";
      }
    }
  }
}
