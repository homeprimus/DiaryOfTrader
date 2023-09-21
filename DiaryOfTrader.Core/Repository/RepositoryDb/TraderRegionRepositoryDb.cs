namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRegionRepositoryDb: RepositoryDb<TraderRegion>, ITraderRegionRepository
  {
    public TraderRegionRepositoryDb(DbContext data) : base(data)
    {
    }
    public override async Task<List<TraderRegion?>> GetAllAsync() => await Entity.Include(e=>e.Sessions).ToListAsync();

    public override async Task<TraderRegion?> GetByIdAsync(long entryId) => await Entity.Where(e => e.ID == entryId).Include(e=>e.Sessions).FirstOrDefaultAsync();

    // public override async Task UpdateAsync(List<TraderRegion> entities)
    // {
    //   foreach (var entity in entities)
    //   {
    //     var existingRegion = Data.Region
    //       .Include(b => b.Sessions)
    //       .FirstOrDefault(b => b.ID == entity.ID);
    //
    //     if (existingRegion == null)
    //     {
    //       Data.Region.Add(entity);
    //     }
    //     else
    //     {
    //       Data.Entry(existingRegion).CurrentValues.SetValues(entity);
    //       foreach (var session in entity.Sessions)
    //       {
    //         var existingSession = existingRegion.Sessions
    //           .FirstOrDefault(p => p.ID == session.ID);
    //
    //         if (existingSession == null)
    //         {
    //           existingRegion.Sessions.Add(session);
    //         }
    //         else
    //         {
    //           Data.Entry(existingSession).CurrentValues.SetValues(session);
    //         }
    //       }
    //
    //       foreach (var session in existingRegion.Sessions)
    //       {
    //         if (!entity.Sessions.Any(p => p.ID == session.ID))
    //         {
    //           Data.Remove(session);
    //         }
    //       }
    //     }
    //   }
    //   
    //   await Data.SaveChangesAsync();
    // }
  }
}
