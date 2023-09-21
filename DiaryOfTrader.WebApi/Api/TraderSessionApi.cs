using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderSessionApi : Api<TraderSession, ITraderSessionRepository>, IApi
  {
    public TraderSessionApi(ILogger<RepositoryDb<TraderSession>> logger) : base(logger)
    {
    }
  }
}
