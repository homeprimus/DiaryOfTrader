using DiaryOfTrader.Core.Repository;

namespace DiaryOfTrader.WebApi.Api
{
  public class MarketReviewTimeFrameApi : Api<MarketReviewTimeFrame, IMarketReviewTimeFrameRepository>, IApi
  {
    public MarketReviewTimeFrameApi(EndPointConfiguration config, ILogger<Api<MarketReviewTimeFrame, IMarketReviewTimeFrameRepository>> logger) : base(config, logger)
    {
    }
  }
}
