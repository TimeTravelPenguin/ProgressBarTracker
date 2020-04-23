using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DonationTracker.Models.ProgressBar;
using SkiaSharp;

namespace DonationTracker.ViewModels
{
  internal class MainWindowViewModel : ViewModelBase
  {
    private readonly ProgBarInfo _progBarInfo;
    public ImageSource IS { get; set; }

    public MainWindowViewModel()
    {
      var back = new ProgRoundRectangle(5, 5, 100, 20, 5, 5, 255, 0, 0, 255);
      var inner = new ProgRoundRectangle(10, 10, 90, 10, 3, 3, 0, 0, 255, 255);
      _progBarInfo = new ProgBarInfo(back, inner);

      var wb = CreateImage(200, 200);
      UpdateImage(wb);
      IS = wb;
    }

    public WriteableBitmap CreateImage(int width, int height)
    {
      return new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, BitmapPalettes.Halftone256Transparent);
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
        _progBarInfo.Background.Draw(canvas);
        _progBarInfo.InnerBar.Draw(canvas);
        canvas.DrawText("SkiaSharp on Wpf!", 50, 100, new SKPaint {Color = new SKColor(0, 0, 0), TextSize = 12});
      }

      writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
      writeableBitmap.Unlock();
    }
  }
}