
namespace DiaryOfTrader.Core.Entity
{
  public class Diary
  {
    public long ID { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public TimeFrame Entered { get; set; }
    public string Trend { get; set; }
    public string Monthly { get; set; }
    public string Daily { get; set; }
    public TradeSession? Session { get; }
    public string Comments { get; }
    public string Deal { get; }
    public string Emotions { get; }
    public List<ScreenShot> Screenshot { get; }
  }

}
