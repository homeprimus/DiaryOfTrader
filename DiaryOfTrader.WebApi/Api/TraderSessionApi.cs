using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderSessionApi : Api<TraderSession, ITraderSessionRepository>, IApi
  {
    public TraderSessionApi(EndPointConfiguration config, ILogger<Api<TraderSession, ITraderSessionRepository>> logger) : base(config, logger)
    {
    }
  }
}
