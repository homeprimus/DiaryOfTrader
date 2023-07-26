namespace DiaryOfTrader.Core.Entity.Economic
{
  public enum Importance
  {
    None = 0,
    Low = 1,
    Moderate = 2,
    High = 3
  }

  public enum EconomicPeriod
  {
    today,
    tomorrow,
    thisWeek,
    nextWeek,
  }

  public class EconomicSchedule: IComparable
  {
    private string[] importance = new[] { "", "Низкая", "Умеренная", "Выссокая" };

    public long ID { get; set; }
    public DateTime Time { get; set; }
    public string Currency { get; set; }
    public int Importance { get; set; }
    public string Description { get; set; }
    public string Factual { get; set; }
    public string Prognosis { get; set; }
    public string Previous { get; set; }
    public string Last { get; set; }
    public string HRef { get; set; }
    public EconomicEvent? Event { get; set; }

    public override string ToString()
    {
      return
        Time.ToString("yyyy.MM.dd HH:mm") + " [" + importance[Importance] + "] " + Currency + " \"" + Description +
        "\"";
    }

    public int CompareTo(object? obj)
    {
      var result = -1;
      if (obj != null)
      {
        if (obj is EconomicSchedule e)
        {
          ;
          result = e.Time.CompareTo(Time);
          if (result == 0)
          {
            result = string.Compare(e.Currency, Currency, StringComparison.Ordinal);
            if (result == 0)
            {
              result = string.Compare(e.HRef, HRef, StringComparison.Ordinal);
            }
          }
        }
      }
      return result;
    }

    public override bool Equals(object? obj)
    {
      return CompareTo(obj) == 0;
    }
  }
}
