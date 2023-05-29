namespace DiaryOfTrader.Core.Entity
{
  /*
   * Обзор рынка
   */
  public class MarketReview: Entity
  {
    public  DateTime DateTime { get; set; }
    public Symbol Symbol { get; set; }

  }
}
