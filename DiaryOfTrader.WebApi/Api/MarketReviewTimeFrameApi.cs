using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class MarketReviewTimeFrameApi : Api<MarketReviewTimeFrame, IMarketReviewTimeFrameRepository>, IApi
  {
    public MarketReviewTimeFrameApi(IOptions<EndPointConfiguration> config, ILogger<Api<MarketReviewTimeFrame, IMarketReviewTimeFrameRepository>> logger) : base(config, logger)
    {
    }
  }
}
