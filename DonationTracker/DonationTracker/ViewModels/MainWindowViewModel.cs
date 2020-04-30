#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2020-04-28 9:40 AM
// 
// Creation Date:
// 2020-04-25 1:31 PM

#endregion

using System.ComponentModel;
using System.Windows.Media;
using DonationTracker.Models;
using DonationTracker.Models.ProgressBar;
using Microsoft.Expression.Interactivity.Core;

namespace DonationTracker.ViewModels
{
  internal class MainWindowViewModel : ViewModelBase
  {
    private readonly ShapeDrawer _drawer;
    public ImageSource ImageSource => _drawer.ImageSource;
    public ProgBarInfo ProgBarInfo { get; } = new ProgBarInfo();
    public DonationLogger Donations { get; }
    public IDonation PlaceholderDonation { get; }
    public ActionCommand CommandRefreshProgBar { get; }
    public ActionCommand CommandAddDonation { get; }

    public MainWindowViewModel()
    {
      _drawer = new ShapeDrawer(ProgBarInfo);
      ((INotifyPropertyChanged) _drawer).PropertyChanged += UpdateImageBinding;

      CommandRefreshProgBar = new ActionCommand(CreateProgressBar);
      CommandAddDonation = new ActionCommand(AddDonation);

      Donations = new DonationLogger();
      PlaceholderDonation = new Donation(Donations.UsdConverter);
    }

    private void UpdateImageBinding(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(ImageSource));
    }

    private void CreateProgressBar()
    {
      _drawer.CreateProgressBar();
    }

    private void AddDonation()
    {
      Donations.DonationHistory.Add(new Donation(PlaceholderDonation));
      PlaceholderDonation.UserName = "";
      PlaceholderDonation.RawAmount = 0;
      PlaceholderDonation.Note = "";
      PlaceholderDonation.IsUsd = false;
    }
  }
}