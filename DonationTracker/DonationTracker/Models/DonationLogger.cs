#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: DonationLogger.cs
// 
// Current Data:
// 2020-05-04 3:45 PM
// 
// Creation Date:
// 2020-04-27 12:49 PM

#endregion

using System.ComponentModel;
using System.Linq;
using PenguinLib.Observable;
using PenguinLib.PropertyChanged;

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

      ((INotifyPropertyChanged) UsdConverter).PropertyChanged += UsdConverterOnPropertyChanged;
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