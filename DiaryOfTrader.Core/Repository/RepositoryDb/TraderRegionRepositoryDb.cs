using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRegionRepositoryDb: RepositoryDb<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepositoryDb(DbContext data, ICache cache, ILogger<TraderRegionRepositoryDb> logger) : base(data, cache, logger)
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
