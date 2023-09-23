
namespace DiaryOfTrader.Core.Repository
{
  public class EndPointConfiguration
  {
    public string EndPoint { get; set; }
    public string Version(string func)
    {
      return "api/v1";
    }
  }
}
