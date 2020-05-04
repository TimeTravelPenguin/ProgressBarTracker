#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgRoundRectangle.cs
// 
// Current Data:
// 2020-05-04 3:45 PM
// 
// Creation Date:
// 2020-04-25 1:31 PM

#endregion

using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
  internal class ProgRoundRectangle : ProgShapeBase
  {
    private float _edgeRadius;
    private float _radiusX;
    private float _radiusY;

    public float EdgeRadius
    {
      get => _edgeRadius;
      set
      {
        SetValue(ref _radiusX, value);
        SetValue(ref _radiusY, value);
        SetValue(ref _edgeRadius, value);
      }
    }

    public float RadiusX
    {
      get => _radiusX;
      set => SetValue(ref _radiusX, value);
    }

    public float RadiusY
    {
      get => _radiusY;
      set => SetValue(ref _radiusY, value);
    }

    public static ProgRoundRectangle Empty => new ProgRoundRectangle(0, 0, 0, 0, 0, 0, 0, 0, 0);

    public ProgRoundRectangle() : this(Empty)
    {
    }

    public ProgRoundRectangle(ProgRoundRectangle rect)
    {
      XPos = rect.XPos;
      YPos = rect.YPos;
      Width = rect.Width;
      Height = rect.Height;
      EdgeRadius = rect.EdgeRadius;
      Red = rect.Red;
      Green = rect.Green;
      Blue = rect.Blue;
      Alpha = rect.Alpha;
    }

    public ProgRoundRectangle(float xPos, float yPos, float width, float height, float edgeRadius, byte red,
      byte green, byte blue, byte alpha) : this(xPos, yPos, width, height, edgeRadius, edgeRadius, red, green,
      blue, alpha)
    {
    }

    public ProgRoundRectangle(float xPos, float yPos, float width, float height, float radX, float radY, byte red,
      byte green, byte blue, byte alpha)
    {
      XPos = xPos;
      YPos = yPos;
      Width = width;
      Height = height;
      RadiusX = radX;
      RadiusY = radY;
      Red = red;
      Green = green;
      Blue = blue;
      Alpha = alpha;
    }

    public override void Draw(SKCanvas canvas)
    {
      canvas.DrawRoundRect(XPos, YPos, Width, Height, RadiusX, RadiusY,
        new SKPaint {Color = new SKColor(Red, Green, Blue, Alpha)});
    }
  }
}