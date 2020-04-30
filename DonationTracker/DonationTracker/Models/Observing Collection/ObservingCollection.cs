#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ObservingCollection.cs
// 
// Current Data:
// 2020-04-30 10:00 PM
// 
// Creation Date:
// 2020-04-30 9:59 PM

#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DonationTracker.Models.Observing_Collection
{
  /// <summary>
  ///   A collection extending <see cref="ObservableCollection{T}" /> that raises a PropertyChanged event when a contained
  ///   object does.
  /// </summary>
  /// <typeparam name="T">
  ///   An object implementing <see cref="INotifyPropertyChanged" />.
  /// </typeparam>
  public class ObservingCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
  {
    public ObservingCollection()
    {
    }

    public ObservingCollection(IEnumerable<T> collection)
    {
      foreach (var item in collection)
      {
        Add(item);
      }
    }

    public new void Add(T item)
    {
      item.PropertyChanged += NotifyCollectionChange;

      base.Add(item);
    }

    public void Add(IEnumerable<T> items)
    {
      foreach (var item in items)
      {
        Add(item);
      }
    }

    public new void Remove(T item)
    {
      item.PropertyChanged -= NotifyCollectionChange;

      base.Remove(item);
    }

    public new void Clear()
    {
      foreach (var item in Items)
      {
        item.PropertyChanged -= NotifyCollectionChange;
      }

      base.Clear();
    }

    private void NotifyCollectionChange(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
      OnPropertyChanged(new PropertyChangedEventArgs(nameof(Items)));
    }
  }
}