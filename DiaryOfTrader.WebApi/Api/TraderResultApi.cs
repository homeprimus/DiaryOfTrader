using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderResultApi : Api<TraderResult, ITraderResultRepository>, IApi
  {
    public TraderResultApi(ILogger<RepositoryDb<TraderResult>> logger) : base(logger)
    {
    }
  }
}
