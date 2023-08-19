
namespace DiaryOfTrader.Core.Entity
{
  /*
   * Обзор рынка
   */
  public class MarketReview: Entity
  {
    public  DateTime DateTime { get; set; } = DateTime.Now;
    public TraderExchange Exchange { get; set; }
    public Symbol Symbol { get; set; }
    //public TraderSession? Session { get; }
    public List<MarketReviewTimeFrame> Frames { get; set; } = new List<MarketReviewTimeFrame>();
  }

  public class MarketReviewTimeFrame : Entity
  {
    [JsonIgnore]
    public MarketReview Market { get; set; }
    public TimeFrame Frame { get; set; }
    public Trend? Trend { get; set; }
    public ScreenShot? Image { get; set; }
  }
}

