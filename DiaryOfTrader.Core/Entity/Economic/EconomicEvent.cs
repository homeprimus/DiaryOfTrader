
namespace DiaryOfTrader.Core.Entity.Economic
{

  public class EconomicEvent
  {
    public long ID { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
    [JsonIgnore]
    public string SourceRef { get; set; }
    [JsonIgnore]
    public string LocalRef { get; set; }
    public override string ToString()
    {
      return Country + " [" + Currency + "] " + " \"" + Description + "\"";
    }
  }
}
