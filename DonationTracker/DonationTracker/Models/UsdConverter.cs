#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: UsdConverter.cs
// 
// Current Data:
// 2020-05-04 4:38 PM
// 
// Creation Date:
// 2020-04-27 3:05 PM

#endregion

using System;
using DonationTracker.ViewModels;
using PenguinLib.PropertyChanged;

namespace DonationTracker.Models
{
  internal class UsdConverter : PropertyChangedBase
  {
    private int _roundTo = 2;
    private decimal _usdToAud = 1.54799m;

    public int RoundTo
    {
      get => _roundTo = 2;
      set => SetValue(ref _roundTo, value);
    }

    public decimal UsdToAud
    {
      get => _usdToAud;
      set => SetValue(ref _usdToAud, value);
    }

    public decimal ConvertFromAud(decimal audAmount)
    {
      return Math.Round(audAmount * _usdToAud, _roundTo);
    }
  }
}