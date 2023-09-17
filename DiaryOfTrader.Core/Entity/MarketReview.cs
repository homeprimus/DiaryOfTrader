
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
    #region fields
    private TraderExchange _exchange;
    private Symbol _symbol;
    private DateTime _dateTime = DateTime.Now;
    #endregion
    public override string Name
    {
      get
      {
        var genereted = (Exchange != null ? Exchange.Name : string.Empty) + ":" + (Symbol != null ? Symbol.Name : string.Empty);
        if (genereted == ":") genereted = string.Empty;
        return
          base.Name != string.Empty &&
          base.Name != genereted
            ? base.Name
            : genereted;
      }
      set { base.Name = value; }
    }

    public DateTime DateTime
    {
      get { return _dateTime; }
      set
      {
        if (_dateTime != value)
        {
          _dateTime = value;
          OnPropertyChanged();
        }
      }
    } 
    public TraderExchange Exchange
    {
      get { return _exchange;}
      set
      {
        if (_exchange != value)
        {
          _exchange = value;
          OnPropertyChanged();
        }
      }
    }

    public Symbol Symbol
    {
      get { return _symbol;}
      set
      {
        if (_symbol != value)
        {
          _symbol = value;
          OnPropertyChanged();
        }
      }
    }
    public List<MarketReviewTimeFrame> Frames { get; set; } = new List<MarketReviewTimeFrame>();

    public void SetFrame(MarketReviewTimeFrame entry)
    {
      entry.Market = this;
      entry.Trend = DiaryOfTrader.TrendRepository.GetAllAsync().Result?.OrderBy(e => e.Order).FirstOrDefault();
      var frames = DiaryOfTrader.TimeFrameRepository.GetAllAsync().Result?.OrderBy(e => e.Order);
      if (Frames.Count > 1)
      {
        var exists = Frames.Where(e=> e.Frame != null).Select(e=> e.Frame).Distinct().ToList();
        entry.Frame = frames?.FirstOrDefault(e => !exists.Contains(e));
      }
      else
      {
        entry.Frame = frames?.FirstOrDefault();
      }
    }

    [NotMapped, JsonIgnore]
    public static IList FrameList => DiaryOfTrader.GetTimeFrame();
    [NotMapped, JsonIgnore]
    public static IList TrendList => DiaryOfTrader.GetTrend();

    [NotMapped, JsonIgnore]
    public static IList SymbolList => DiaryOfTrader.GetSymbol();
    [NotMapped, JsonIgnore]
    public static IList ExchangeList => DiaryOfTrader.GetTraderExchange();
  }


}

