#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgBarInfo.cs
// 
// Current Data:
// 2020-04-26 1:16 AM
// 
// Creation Date:
// 2020-04-25 1:28 PM

#endregion

using DonationTracker.Types;

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
            Background = new ProgRoundRectangle(0, 0, 100, 30, 7, 7, 66, 135, 245, 255);
            InnerBar = new ProgRoundRectangle(10, 10, 80, 20, 7, 7, 61, 67, 184, 255);
        }

        public ProgBarInfo(ProgRoundRectangle background, ProgRoundRectangle inner)
        {
            Background = background;
            InnerBar = inner;
        }
    }
}