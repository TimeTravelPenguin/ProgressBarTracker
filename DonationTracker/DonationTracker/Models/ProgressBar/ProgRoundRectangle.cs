#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgRoundRectangle.cs
// 
// Current Data:
// 2020-04-23 5:23 PM
// 
// Creation Date:
// -- 

#endregion

using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
  internal class ProgRoundRectangle : ProgShapeBase
  {
    public float RadiusX { get; set; }
    public float RadiusY { get; set; }

    public static ProgRoundRectangle Zero => new ProgRoundRectangle(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

    public ProgRoundRectangle(float xpos, float ypos, float width, float height, float radX, float radY, byte red,
      byte green, byte blue, byte alpha)
    {
      XPos = xpos;
      YPos = ypos;
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