namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class MarketReviewTimeFrameRepositoryDb : RepositoryDb<MarketReviewTimeFrame>, IMarketReviewTimeFrameRepository
  {
    public MarketReviewTimeFrameRepositoryDb(DbContext data) : base(data)
    {
    }
  }
}
