using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRegionRepositoryDb: RepositoryDb<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepositoryDb(DbContext data) : base(data)
    {
    }
    public override async Task<List<TraderRegion?>> GetAllAsync() => await Entity.Include(e=>e.Sessions).ToListAsync();

  }
}
