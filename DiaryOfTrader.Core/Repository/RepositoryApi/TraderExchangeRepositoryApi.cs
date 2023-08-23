
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderExchangeRepositoryApi : RepositoryApi<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryApi(string root) : base(root)
    {
    }
  }
}
