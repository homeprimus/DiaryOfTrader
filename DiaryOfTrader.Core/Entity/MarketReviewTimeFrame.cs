
namespace DiaryOfTrader.Core.Entity
{
  [DescriptionRes("MarketReviewTimeFrame")]
  [Serializable]
  public class MarketReviewTimeFrame : Entity
  {
    #region fields

    private TimeFrame _frame;
    private Trend? _trend;
    private ScreenShot? _screenShot = new ();
    #endregion

    public override string Name
    {
      get 
      { 
        return 
        _frame != null ? _frame.Name : base.Name;
      }
      set { base.Name = value; }
    }

    [JsonIgnore]
    public MarketReview Market { get; set; }

    public TimeFrame Frame
    {
      get { return _frame; }
      set
      {
        if (_frame != value)
        {
          _frame = value;
          OnPropertyChanged();
        }
      }
    }

    public Trend? Trend
    {
      get { return _trend; }
      set
      {
        if (_trend != value)
        {
          _trend = value;
          OnPropertyChanged();
        }
      }
    }

    public ScreenShot? ScreenShot
    {
      get { return _screenShot;}
      set
      {
        if (_screenShot != value)
        {
          _screenShot = value;
          OnPropertyChanged();
        }
      }
    } 

  }
}
