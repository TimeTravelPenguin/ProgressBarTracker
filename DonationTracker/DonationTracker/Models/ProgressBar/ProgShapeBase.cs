#region Title Header

// Name: Phillip Smith
// 
// Solution: DonationTracker
// Project: DonationTracker
// File Name: ProgShapeBase.cs
// 
// Current Data:
// 2020-05-04 4:38 PM
// 
// Creation Date:
// 2020-04-25 1:30 PM

#endregion

using System.Windows.Media;
using DonationTracker.ViewModels;
using PenguinLib.PropertyChanged;
using SkiaSharp;

namespace DonationTracker.Models.ProgressBar
{
  internal abstract class ProgShapeBase : PropertyChangedBase, IProgShape
  {
    private byte _alpha;
    private byte _blue;
    private Color _color;
    private byte _green;
    private float _height;
    private byte _red;
    private float _width;
    private float _xPos;
    private float _yPos;

    public Color Color
    {
      get => _color;
      set
      {
        SetValue(ref _color, value);
        Red = Color.R;
        Green = Color.G;
        Blue = Color.B;
        Alpha = Color.A;
      }
    }

    public float XPos
    {
      get => _xPos;
      set => SetValue(ref _xPos, value);
    }

    public float YPos
    {
      get => _yPos;
      set => SetValue(ref _yPos, value);
    }

    public float Width
    {
      get => _width;
      set => SetValue(ref _width, value);
    }

    public float Height
    {
      get => _height;
      set => SetValue(ref _height, value);
    }

    public byte Red
    {
      get => _red;
      set => SetValue(ref _red, value);
    }

    public byte Green
    {
      get => _green;
      set => SetValue(ref _green, value);
    }

    public byte Blue
    {
      get => _blue;
      set => SetValue(ref _blue, value);
    }

    public byte Alpha
    {
      get => _alpha;
      set => SetValue(ref _alpha, value);
    }

    public abstract void Draw(SKCanvas canvas);
  }
}