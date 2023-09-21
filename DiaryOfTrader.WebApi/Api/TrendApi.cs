using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TrendApi : Api<Trend, ITrendRepository>, IApi
  {
    public TrendApi(ILogger<RepositoryDb<Trend>> logger) : base(logger)
    {
    }
  }
}
