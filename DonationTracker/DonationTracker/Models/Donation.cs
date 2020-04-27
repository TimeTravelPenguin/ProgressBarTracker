#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: Donation.cs
// 
// Current Data:
// 2020-04-27 8:31 PM
// 
// Creation Date:
// 2020-04-27 1:27 PM

#endregion

using System;
using DonationTracker.Types;

namespace DonationTracker.Models
{
  internal class Donation : PropertyChangedBase, IDonation
  {
    private decimal _amount;
    private bool _isUsd;
    private string _note;
    private DateTime _timestamp;
    private string _userName;

    public decimal RawAmount
    {
      get => _amount;
      set => SetValue(ref _amount, value);
    }

    public bool IsUsd
    {
      get => _isUsd;
      set
      {
        SetValue(ref _isUsd, value);
        OnPropertyChanged(nameof(AudAmount));
        OnPropertyChanged(nameof(RawAmount));
      }
    }

    public UsdConverter UsdConverter { get; }

    public string UserName
    {
      get => _userName;
      set => SetValue(ref _userName, value);
    }

    public DateTime TimeStamp
    {
      get => _timestamp;
      set => SetValue(ref _timestamp, value);
    }

    public decimal AudAmount =>
      _isUsd
        ? UsdConverter.ConvertFromAud(_amount)
        : Math.Round(_amount, UsdConverter.RoundTo);

    public string Note
    {
      get => _note;
      set => SetValue(ref _note, value);
    }

    public Donation(UsdConverter converter)
    {
      UsdConverter = converter;
    }

    public Donation(IDonation donation)
    {
      UserName = donation.UserName;
      TimeStamp = DateTime.Now;
      RawAmount = donation.RawAmount;
      Note = donation.Note;
      IsUsd = donation.IsUsd;
      UsdConverter = donation.UsdConverter;
    }
  }
}