using System.Collections.Generic;
using DiaryOfTrader.Core.Properties;

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
    yesterday = 0,
    today = 1,
    tomorrow = 2,
    thisWeek = 3,
    nextWeek = 4,
  }

  public class EconomicSchedule: IComparable
  {
    private static List<KeyValuePair<Importance, string>> importances =
      new List<KeyValuePair<Importance, string>>(
      new []{
        new KeyValuePair<Importance, string>(Economic.Importance.None, Resources.EconomicImportanceNone),
        new KeyValuePair<Importance, string>(Economic.Importance.Low, Resources.EconomicImportanceLow),
        new KeyValuePair<Importance, string>(Economic.Importance.Moderate, Resources.EconomicImportanceModerate),
        new KeyValuePair<Importance, string>(Economic.Importance.High, Resources.EconomicImportanceHigh)
      });

    public long ID { get; set; }
    public DateTime Time { get; set; }
    public string Currency { get; set; } = string.Empty;
    public int Importance { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Factual { get; set; } = string.Empty;
    public string Prognosis { get; set; } = string.Empty;
    public string Previous { get; set; } = string.Empty;
    public string Last { get; set; } = string.Empty;
    public string HRef { get; set; } = string.Empty;
    public EconomicEvent? Event { get; set; }

    public static List<KeyValuePair<Importance, string>> Importances
    {
      get { return importances; }
    }
    public override string ToString()
    {
      
      return
        Time.ToString("yyyy.MM.dd HH:mm") + " [" + importances[Importance].Value + "] " + Currency + " \"" + Description +
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
