
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Entity
{
  /*
   * Обзор рынка
   */
  [DescriptionRes("MarketReview")]
  [Serializable]
  public class MarketReview: Entity
  {
    public  DateTime DateTime { get; set; } = DateTime.Now;
    public TraderExchange Exchange { get; set; }
    public Symbol Symbol { get; set; }
    //public TraderSession? Session { get; }
    //public EconomicCalendar? Events { get; }
    public List<MarketReviewTimeFrame> Frames { get; set; } = new List<MarketReviewTimeFrame>();

    public MarketReviewTimeFrame AddFrame()
    {
      var result = new MarketReviewTimeFrame();
      using var db = new DiaryOfTraderCtx();
      result.Trend = db.Trend.FirstOrDefault();
      if (Frames.Count > 0)
      {
        result.Frame = db.Frame.FirstOrDefault(e => Frames.Any(f => f.Frame != e));
      }
      else
      {
        result.Frame = db.Frame.OrderBy(e=>e.Order).FirstOrDefault();
      }

      return result;
    }

    [NotMapped, JsonIgnore]
    public static IList FrameList => Get<TimeFrame>();
    [NotMapped, JsonIgnore]
    public static IList TrendList => Get<Trend>();

    [NotMapped, JsonIgnore]
    public static IList SymbolList => Get<Symbol>();
    [NotMapped, JsonIgnore]
    public static IList ExchangeList => Get<TraderExchange>();
  }
  [Serializable]
  public class MarketReviewTimeFrame : Entity
  {
    [JsonIgnore]
    public MarketReview Market { get; set; }
    public TimeFrame Frame { get; set; }
    public Trend? Trend { get; set; }
    public ScreenShot? Image { get; set; }

  }
}

