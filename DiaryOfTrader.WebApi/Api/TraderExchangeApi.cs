using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderExchangeApi : Api<TraderExchange, ITraderExchangeRepository>, IApi
  {
    public TraderExchangeApi(ILogger<RepositoryDb<TraderExchange>> logger) : base(logger)
    {
    }
  }
}

