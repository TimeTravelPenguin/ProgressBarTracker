#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ShapeDrawer.cs
// 
// Current Data:
// 2020-05-04 3:45 PM
// 
// Creation Date:
// 2020-04-28 9:18 AM

#endregion

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DonationTracker.Models.ProgressBar;
using PenguinLib.PropertyChanged;
using SkiaSharp;

namespace DonationTracker.Models
{
  internal class ShapeDrawer : PropertyChangedBase
  {
    private readonly ProgBarInfo _progBarInfo;

    private ImageSource _imageSource;

    public ImageSource ImageSource
    {
      get => _imageSource;
      set => SetValue(ref _imageSource, value);
    }

    public ShapeDrawer(ProgBarInfo progBarInfo)
    {
      _progBarInfo = progBarInfo;
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
        _progBarInfo.Draw(canvas);
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

    public void CreateProgressBar()
    {
      var wb = CreateImage(_progBarInfo.Width, _progBarInfo.Height, _progBarInfo.Dpi);
      UpdateImage(wb);
      ImageSource = wb;
      SaveImage();
    }
  }
}