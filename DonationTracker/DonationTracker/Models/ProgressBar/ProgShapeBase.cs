#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgShapeBase.cs
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
  internal abstract class ProgShapeBase : IProgShape
  {
    public float XPos { get; set; }
    public float YPos { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }
    public byte Alpha { get; set; }
    public abstract void Draw(SKCanvas canvas);
  }
}