#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgRoundRectangle.cs
// 
// Current Data:
// 2020-04-26 1:11 AM
// 
// Creation Date:
// 2020-04-25 1:31 PM

#endregion

using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
    internal class ProgRoundRectangle : ProgShapeBase
    {
        private float _radiusX;
        private float _radiusY;

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