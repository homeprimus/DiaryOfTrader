
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderSessionRepositoryDb: RepositoryDb<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }
  }
}
