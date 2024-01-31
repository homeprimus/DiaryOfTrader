
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class MarketReviewTimeFrameRepositoryApi : RepositoryApi<MarketReviewTimeFrame>, IMarketReviewTimeFrameRepository
  {
    public MarketReviewTimeFrameRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<MarketReviewTimeFrame>> logger) : base(config, client, logger)
    {
    }
  }
}
