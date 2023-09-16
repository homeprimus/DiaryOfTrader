
namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class MarketReviewRepositoryDb : RepositoryDb<MarketReview>, IMarketReviewRepository
  {
    public MarketReviewRepositoryDb(DbContext data) : base(data)
    {
    }
  }
}
