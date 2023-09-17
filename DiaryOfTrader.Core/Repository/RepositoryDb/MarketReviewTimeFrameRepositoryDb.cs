namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class MarketReviewTimeFrameRepositoryDb : RepositoryDb<MarketReviewTimeFrame>, IMarketReviewTimeFrameRepository
  {
    public MarketReviewTimeFrameRepositoryDb(DbContext data) : base(data)
    {
    }
    public override async Task<List<MarketReviewTimeFrame?>> GetAllAsync()
    {
      return await Entity
        .Include(p => p.Trend)
        .Include(p => p.Frame)
        .Include(p => p.ScreenShot)
        .ToListAsync();
    }

  }
}
