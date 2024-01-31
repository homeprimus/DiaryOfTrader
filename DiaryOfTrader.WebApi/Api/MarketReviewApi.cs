using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class MarketReviewApi : Api<MarketReview, IMarketReviewRepository>, IApi
  {
    public MarketReviewApi(IOptions<EndPointConfiguration> config, ILogger<Api<MarketReview, IMarketReviewRepository>> logger) : base(config, logger)
    {
    }
  }
}
