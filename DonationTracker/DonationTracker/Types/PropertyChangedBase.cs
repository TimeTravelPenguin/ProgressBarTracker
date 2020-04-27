#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: PropertyChangedBase.cs
// 
// Current Data:
// 2020-04-28 9:39 AM
// 
// Creation Date:
// 2020-04-25 1:30 PM

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DonationTracker.Types
{
  public abstract class PropertyChangedBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (string.IsNullOrEmpty(propertyName))
      {
        throw new ArgumentNullException(nameof(propertyName));
      }

      if (EqualityComparer<T>.Default.Equals(field, value))
      {
        return false;
      }

      field = value;
      NotifyPropertyChanged(propertyName);

      return true;
    }
  }
}