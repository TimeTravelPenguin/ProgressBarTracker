#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2020-04-27 4:02 PM
// 
// Creation Date:
// 2020-04-25 1:31 PM

#endregion

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DonationTracker.Models;
using DonationTracker.Models.ProgressBar;
using Microsoft.Expression.Interactivity.Core;
using SkiaSharp;

namespace DonationTracker.ViewModels
{
  internal class MainWindowViewModel : ViewModelBase
  {
    private ImageSource _imageSource;
    public ProgBarInfo ProgBarInfo { get; } = new ProgBarInfo();
    public DonationLogger Donations { get; }
    public IDonation PlaceholderDonation { get; }

    public ImageSource ImageSource
    {
      get => _imageSource;
      set => SetValue(ref _imageSource, value);
    }

    public ActionCommand CommandRefreshProgBar { get; }
    public ActionCommand CommandAddDonation { get; }

    public MainWindowViewModel()
    {
      CommandRefreshProgBar = new ActionCommand(CreateProgressBar);
      CommandAddDonation = new ActionCommand(AddDonation);

      Donations = new DonationLogger();
      PlaceholderDonation = new Donation(Donations.UsdConverter);
    }

    private void AddDonation()
    {
      Donations.DonationHistory.Add(new Donation(PlaceholderDonation));
      PlaceholderDonation.UserName = "";
      PlaceholderDonation.RawAmount = 0;
      PlaceholderDonation.Note = "";
      PlaceholderDonation.IsUsd = false;
    }

    private void CreateProgressBar()
    {
      var wb = CreateImage(ProgBarInfo.Width, ProgBarInfo.Height, ProgBarInfo.Dpi);
      UpdateImage(wb);
      ImageSource = wb;
      SaveImage();
    }

    public WriteableBitmap CreateImage(int width, int height, double dpi)
    {
      return new WriteableBitmap(width, height, dpi, dpi, PixelFormats.Bgra32,
        BitmapPalettes.Halftone256Transparent);
    }

    public void UpdateImage(WriteableBitmap writeableBitmap)
    {
      var width = (int) writeableBitmap.Width;
      var height = (int) writeableBitmap.Height;

      writeableBitmap.Lock();
      using (var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Bgra8888),
        writeableBitmap.BackBuffer, width * 4))
      {
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.Transparent);
        ProgBarInfo.Draw(canvas);
      }

      writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
      writeableBitmap.Unlock();
    }

    public void SaveImage()
    {
      var image = ImageSource as BitmapSource;
      using (var fileStream = new FileStream(
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "file.png"),
        FileMode.Create))
      {
        BitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image ?? throw new ArgumentNullException(nameof(image))));
        encoder.Save(fileStream);
      }
    }
  }
}