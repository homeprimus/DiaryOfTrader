
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TraderResultRepositoryDb: RepositoryDb<TraderResult>, ITraderResultRepository
  {
    public TraderResultRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }

  }
}
