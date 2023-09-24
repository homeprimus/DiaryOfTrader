
namespace DiaryOfTrader.Core.Repository
{
  public class EndPointConfiguration
  {
    public string EndPoint { get; set; } = string.Empty;
    public string Default { get; set; } = "1";
    public string Version(string func)
    {
      return $"api/v{Default}";
    }
  }
}
