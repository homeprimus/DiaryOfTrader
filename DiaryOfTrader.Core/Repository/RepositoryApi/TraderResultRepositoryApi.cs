using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderResultRepositoryApi: RepositoryApi<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryApi(string root) : base(root)
    {
    }
  }
}
