#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: IProgShape.cs
// 
// Current Data:
// 2020-04-23 5:22 PM
// 
// Creation Date:
// -- 

#endregion

using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
  internal interface IProgShape
  {
    void Draw(SKCanvas canvas);
  }
}