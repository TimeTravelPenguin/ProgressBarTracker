#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: DonationLogger.cs
// 
// Current Data:
// 2020-04-30 10:03 PM
// 
// Creation Date:
// 2020-04-27 12:49 PM

#endregion

using System.ComponentModel;
using System.Linq;
using DonationTracker.Models.Observing_Collection;
using DonationTracker.Types;

namespace DonationTracker.Models
{
  internal class DonationLogger : PropertyChangedBase
  {
    public ObservingCollection<IDonation> DonationHistory { get; } = new ObservingCollection<IDonation>();
    public decimal TotalAmount => DonationHistory.Select(x => x.AudAmount).Sum();
    public UsdConverter UsdConverter { get; } = new UsdConverter();

    public DonationLogger()
    {
      ((INotifyPropertyChanged) DonationHistory).PropertyChanged += TotalAmountChanged;
      UsdConverter.PropertyChanged += UsdConverterOnPropertyChanged;
    }

    private void TotalAmountChanged(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(TotalAmount));
    }

    private void UsdConverterOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(DonationHistory));
    }

    public void Add(IDonation donation)
    {
      DonationHistory.Add(donation);
    }
  }
}