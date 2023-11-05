using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.Core.Repository.RepositoryDb;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TrendApi : Api<Trend, ITrendRepository>, IApi
  {
    public TrendApi(IOptions<EndPointConfiguration> config, ILogger<Api<Trend, ITrendRepository>> logger) : base(config, logger)
    {
    }
  }
}
