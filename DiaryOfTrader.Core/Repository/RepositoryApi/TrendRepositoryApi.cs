
namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TrendRepositoryApi : RepositoryApi<Trend>, ITrendRepository
  {
    public TrendRepositoryApi(string root) : base(root)
    {
    }
  }
}
