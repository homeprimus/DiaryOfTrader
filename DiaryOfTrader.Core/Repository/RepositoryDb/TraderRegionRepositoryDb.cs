using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRegionRepositoryDb: RepositoryDb<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepositoryDb(DbContext data, ICache cache) : base(data, cache)
    {
    }

    public override async Task<List<TraderRegion?>> GetAllAsync()
    {
      var result = Cache.Get<List<TraderRegion?>>(CacheKey);
      if (result == null)
      {
        result = await Entity.Include(e => e.Sessions).ToListAsync();
        Cache.Set(CacheKey, result);
      }
      return result;
    }
  }
}
