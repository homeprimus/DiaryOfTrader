
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class MarketReviewRepositoryDb : RepositoryDb<MarketReview>, IMarketReviewRepository
  {
    public MarketReviewRepositoryDb(DbContext data, ICache cache) : base(data, cache)
    {
    }

    public override async Task<List<MarketReview?>> GetAllAsync()
    {

      var result = Cache.Get<List<MarketReview?>>(CacheKey);
      if (result == null)
      {
        _ = Data.Frame.ToList();
        _ = Data.Trend.ToList();
        _ = Data.ScreenShot.ToList();
        result = await Entity
          .Include(p => p.Symbol)
          .Include(p => p.Exchange)
          .Include(p => p.Frames)
          .ToListAsync();

        Cache.Set(CacheKey, result);
      }
      return result;
    }

  }
}
