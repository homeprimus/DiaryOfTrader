using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class MarketReviewApi : Api<MarketReview, IMarketReviewRepository>, IApi
  {
    public MarketReviewApi(ILogger<RepositoryDb<MarketReview>> logger) : base(logger)
    {
    }
  }
}
