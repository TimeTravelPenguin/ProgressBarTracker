#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: IProgShape.cs
// 
// Current Data:
// 2020-04-26 4:15 PM
// 
// Creation Date:
// 2020-04-25 1:27 PM

#endregion

using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
  internal interface IProgShape
  {
    void Draw(SKCanvas canvas);
  }
}