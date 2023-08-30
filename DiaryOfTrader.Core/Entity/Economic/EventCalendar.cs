
namespace DiaryOfTrader.Core.Entity.Economic
{
  public class EventCalendar
  {
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public string Currency { get; set; }
    public string Importance { get; set; }
    public string Description { get; set; }
    public string Factual { get; set; }
    public string Prognosis { get; set; }
    public string Previous { get; set; }
    public string Node { get; set; }

    public override string ToString()
    {
      return Date.ToString("YYYY.MM.dd HH:mm") + $" [{Currency}] [{Importance}] {Description}";
    }
  }
}
