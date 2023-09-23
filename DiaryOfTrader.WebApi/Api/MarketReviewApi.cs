using DiaryOfTrader.Core.Repository;

namespace DiaryOfTrader.WebApi.Api
{
  public class MarketReviewApi : Api<MarketReview, IMarketReviewRepository>, IApi
  {
    public MarketReviewApi(EndPointConfiguration config, ILogger<Api<MarketReview, IMarketReviewRepository>> logger) : base(config, logger)
    {
    }
  }
}
