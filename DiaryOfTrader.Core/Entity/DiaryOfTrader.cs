
using DiaryOfTrader.Core.Data;

namespace DiaryOfTrader.Core.Entity
{
  public class DiaryOfTrader: Element
  {
    #region

    private static DiaryOfTrader _diaryOfTrader = new();
    private Trader _trader;
    #endregion

    private DiaryOfTrader()
    {
    }
    protected override void Free()
    {
      base.Free();
    }

    public static DiaryOfTrader Default { get; } = _diaryOfTrader;
    public Trader Trader
    {
      get { return _trader;}
      set
      {
        if (_trader != value)
        {
          _trader = value;
          OnPropertyChanged();
        }
      }
    }

    public List<Diary> Diaries()
    {
      using var context = new DiaryOfTraderCtx();
      return context.Diary.ToList();
    }

    public List<MarketReview> MarketReviews()
    {
      using var contex = new DiaryOfTraderCtx();
      return contex.MarketReview.ToList();
    }
  }
}
