#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: IDonation.cs
// 
// Current Data:
// 2020-05-04 4:38 PM
// 
// Creation Date:
// 2020-04-27 1:25 PM

#endregion

using System;
using System.ComponentModel;

namespace DonationTracker.Models
{
  internal interface IDonation : INotifyPropertyChanged
  {
    string UserName { get; set; }
    DateTime TimeStamp { get; set; }
    decimal RawAmount { get; set; }
    decimal AudAmount { get; }
    string Note { get; set; }
    UsdConverter UsdConverter { get; }
    bool IsUsd { get; set; }
  }
}