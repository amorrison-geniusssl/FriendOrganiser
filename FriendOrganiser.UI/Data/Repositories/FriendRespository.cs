﻿using FriendOrganiser.DataAccess;
using FriendOrganiser.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganiser.UI.Data.Repositories
{
  public class FriendRespository : IFriendRepository
  {
    private FriendOrganiserDbContext _context;

    public FriendRespository(FriendOrganiserDbContext context)
    {
      _context = context;
    }

    public void Add(Friend friend)
    {
      _context.Friends.Add(friend);
    }

    public async Task<Friend> GetByIdAsync(int friendId)
    {
      return await _context.Friends
        .Include(f => f.PhoneNumbers)
        .SingleAsync(f => f.Id == friendId);
    }

    public bool HasChanges()
    {
      return _context.ChangeTracker.HasChanges();
    }

    public void Remove(Friend model)
    {
      _context.Friends.Remove(model);
    }

    public void RemovePhoneNumber(FriendPhoneNumber model)
    {
      _context.FriendPhoneNumbers.Remove(model);
    }

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}
