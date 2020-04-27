#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: IDonation.cs
// 
// Current Data:
// 2020-04-27 8:17 PM
// 
// Creation Date:
// 2020-04-27 1:25 PM

#endregion

using System;

namespace DonationTracker.Models
{
  internal interface IDonation
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