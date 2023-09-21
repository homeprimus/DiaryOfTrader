
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderRepositoryDb : RepositoryDb<Trader>, ITraderRepository
  {
    public TraderRepositoryDb(DbContext data, ICache cache, ILogger<TraderRepositoryDb> logger) : base(data, cache, logger)
    {
    }
    public async Task<Trader> Search(string user, string password)
    {
      return await Entity.Where(e => e.Name == user && e.Password == password).FirstOrDefaultAsync();
    }
  }
}
