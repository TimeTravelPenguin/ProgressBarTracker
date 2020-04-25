#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: MainWindowViewModel.cs
// 
// Current Data:
// 2020-04-26 1:21 AM
// 
// Creation Date:
// 2020-04-25 1:31 PM

#endregion

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DonationTracker.Models.ProgressBar;
using Microsoft.Expression.Interactivity.Core;
using SkiaSharp;

namespace DonationTracker.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ImageSource _imageSource;
        public ProgBarInfo ProgBarInfo { get; } = new ProgBarInfo();

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetValue(ref _imageSource, value);
        }

        public ActionCommand CommandRefreshProgBar { get; }

        public MainWindowViewModel()
        {
            CommandRefreshProgBar = new ActionCommand(CreateProgressBar);
        }

        private void CreateProgressBar()
        {
            var wb = CreateImage(ProgBarInfo.Width, ProgBarInfo.Height, ProgBarInfo.Dpi);
            UpdateImage(wb);
            ImageSource = wb;
        }

        public WriteableBitmap CreateImage(int width, int height, double dpi)
        {
            return new WriteableBitmap(width, height, dpi, dpi, PixelFormats.Bgra32,
                BitmapPalettes.Halftone256Transparent);
        }

        public void UpdateImage(WriteableBitmap writeableBitmap)
        {
            int width = (int) writeableBitmap.Width,
                height = (int) writeableBitmap.Height;

            writeableBitmap.Lock();
            using (var surface = SKSurface.Create(new SKImageInfo(width, height, SKColorType.Bgra8888),
                writeableBitmap.BackBuffer, width * 4))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.Transparent);
                ProgBarInfo.Background.Draw(canvas);
                ProgBarInfo.InnerBar.Draw(canvas);
                canvas.DrawText("SkiaSharp on Wpf!", 50, 100,
                    new SKPaint {Color = new SKColor(0, 0, 0), TextSize = 12});
            }

            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            writeableBitmap.Unlock();
        }
    }
}