
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class MarketReviewRepositoryApi : RepositoryApi<MarketReview>, IMarketReviewRepository
  {
    public MarketReviewRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<MarketReview>> logger) : base(config, client, logger)
    {
    }
  }
}
