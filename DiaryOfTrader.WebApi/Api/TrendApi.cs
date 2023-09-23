using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class TrendApi : Api<Trend, ITrendRepository>, IApi
  {
    public TrendApi(EndPointConfiguration config, ILogger<Api<Trend, ITrendRepository>> logger) : base(config, logger)
    {
    }
  }
}
