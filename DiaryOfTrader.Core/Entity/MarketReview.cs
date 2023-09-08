
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
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


    [NotMapped, JsonIgnore]
    public static IList Symbols
    {
      get
      {
        var result = new List<KeyValuePair<string, Symbol>>();
        using var db = new DiaryOfTraderCtx();
        foreach (var symbol in db.Symbol.ToList())
        {
          result.Add(new KeyValuePair<string, Symbol>(symbol.Name, symbol));
        }
        return result.ToArray();
      }
    }
    [NotMapped, JsonIgnore]
    public static IList Exchanges
    {
      get
      {
        var result = new List<KeyValuePair<string, TraderExchange>>();
        using var db = new DiaryOfTraderCtx();
        foreach (var exchange in db.Exchange.ToList())
        {
          result.Add(new KeyValuePair<string, TraderExchange>(exchange.Name, exchange));
        }
        return result.ToArray();
      }
    }
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

