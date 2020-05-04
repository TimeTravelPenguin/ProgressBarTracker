#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgBarInfo.cs
// 
// Current Data:
// 2020-05-04 4:38 PM
// 
// Creation Date:
// 2020-04-25 1:28 PM

#endregion

using DonationTracker.ViewModels;
using PenguinLib.PropertyChanged;
using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
  internal class ProgBarInfo : PropertyChangedBase
  {
    private double _dpi;
    private int _height;
    private int _width;
    public ProgRoundRectangle Background { get; }
    public ProgRoundRectangle InnerBar { get; }

    public int Height
    {
      get => _height;
      set => SetValue(ref _height, value);
    }

    public int Width
    {
      get => _width;
      set => SetValue(ref _width, value);
    }

    public double Dpi
    {
      get => _dpi;
      set => SetValue(ref _dpi, value);
    }

    public ProgBarInfo()
    {
      // Demo default data
      Background = new ProgRoundRectangle(0, 0, 100, 30, 7, 7, 66, 135, 245, 255);
      InnerBar = new ProgRoundRectangle(10, 10, 80, 20, 7, 7, 61, 67, 184, 255);
    }

    public ProgBarInfo(ProgRoundRectangle background, ProgRoundRectangle inner)
    {
      Background = background;
      InnerBar = inner;
    }

    public void Draw(SKCanvas canvas)
    {
      Background.Draw(canvas);
      InnerBar.Draw(canvas);
    }
  }
}