
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRepositoryDb : RepositoryDb<Trader>, ITraderRepository
  {
    public TraderRepositoryDb(DbContext data, ICache cache) : base(data, cache)
    {
    }
    public async Task<Trader> Search(string user, string password)
    {
      return await Entity.Where(e => e.Name == user && e.Password == password).FirstOrDefaultAsync();
    }
  }
}
