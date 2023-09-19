
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TrendRepositoryDb: RepositoryDb<Trend>, ITrendRepository
  {
    public TrendRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }
  }
}
