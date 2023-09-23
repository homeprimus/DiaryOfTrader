
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  internal class MarketReviewTimeFrameRepositoryApi : RepositoryApi<MarketReviewTimeFrame>, IMarketReviewTimeFrameRepository
  {
    public MarketReviewTimeFrameRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<MarketReviewTimeFrame>> logger) : base(config, client, logger)
    {
    }
  }
}
