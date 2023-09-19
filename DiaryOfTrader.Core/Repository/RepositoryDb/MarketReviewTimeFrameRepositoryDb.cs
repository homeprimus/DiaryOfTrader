using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class MarketReviewTimeFrameRepositoryDb : RepositoryDb<MarketReviewTimeFrame>, IMarketReviewTimeFrameRepository
  {
    public MarketReviewTimeFrameRepositoryDb(DbContext data, ICache cache) : base(data, cache)
    {
    }
    public override async Task<List<MarketReviewTimeFrame?>> GetAllAsync()
    {
      var result = Cache.Get<List<MarketReviewTimeFrame?>>(CacheKey);
      if (result == null)
      {
        result = await Entity
          .Include(p => p.Trend)
          .Include(p => p.Frame)
          .Include(p => p.ScreenShot)
          .ToListAsync();

        Cache.Set(CacheKey, result);
      }
      return result;
    }

  }
}
