namespace DonationTracker.Models.ProgressBar
{
  internal class ProgBarInfo
  {
    public ProgRoundRectangle Background { get; }
    public ProgRoundRectangle InnerBar { get; }

    public ProgBarInfo()
    {
      Background = ProgRoundRectangle.Zero;
      InnerBar = ProgRoundRectangle.Zero;
    }

    public ProgBarInfo(ProgRoundRectangle background, ProgRoundRectangle inner)
    {
      Background = background;
      InnerBar = inner;
    }
  }
}