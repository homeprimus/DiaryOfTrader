using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class MarketReviewTimeFrameApi : Api<MarketReviewTimeFrame, IMarketReviewTimeFrameRepository>, IApi
  {
    public MarketReviewTimeFrameApi(ILogger<RepositoryDb<MarketReviewTimeFrame>> logger) : base(logger)
    {
    }
  }
}
