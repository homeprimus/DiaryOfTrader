using Microsoft.EntityFrameworkCore;

namespace DiaryOfTrader.WebApi.Repository
{
  public class TraderRegionRepository: Repository<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepository(DbContext data) : base(data)
    {
    }
    public override async Task<List<TraderRegion?>> GetAllAsync() => await Entity.Include(e=>e.Sessions).ToListAsync();

  }
}
