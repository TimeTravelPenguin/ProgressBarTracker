#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: DonationLogger.cs
// 
// Current Data:
// 2020-04-27 7:57 PM
// 
// Creation Date:
// 2020-04-27 12:49 PM

#endregion

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using DonationTracker.Types;

namespace DonationTracker.Models
{
  internal class DonationLogger : PropertyChangedBase
  {
    public ObservableCollection<IDonation> DonationHistory { get; } = new ObservableCollection<IDonation>();
    public decimal TotalAmount => DonationHistory.Select(x => x.AudAmount).Sum();
    public UsdConverter UsdConverter { get; } = new UsdConverter();

    public DonationLogger()
    {
      DonationHistory.CollectionChanged += DonationHistoryChanged;
      UsdConverter.PropertyChanged += UsdConverterOnPropertyChanged;
    }

    private void UsdConverterOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(DonationHistory));
    }

    private void DonationHistoryChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        foreach (INotifyPropertyChanged item in e.NewItems)
        {
          item.PropertyChanged += ItemPropertyChanged;
        }
      }

      if (e.Action == NotifyCollectionChangedAction.Remove)
      {
        foreach (INotifyPropertyChanged item in e.OldItems)
        {
          item.PropertyChanged -= ItemPropertyChanged;
        }
      }

      OnPropertyChanged(nameof(TotalAmount));
    }

    private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(TotalAmount));
    }

    public void Add(IDonation donation)
    {
      DonationHistory.Add(donation);
    }
  }
}