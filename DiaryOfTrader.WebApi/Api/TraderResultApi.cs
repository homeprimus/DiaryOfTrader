using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderResultApi : Api<TraderResult, ITraderResultRepository>, IApi
  {
    public TraderResultApi(EndPointConfiguration config, ILogger<Api<TraderResult, ITraderResultRepository>> logger) : base(config, logger)
    {
    }
  }
}
