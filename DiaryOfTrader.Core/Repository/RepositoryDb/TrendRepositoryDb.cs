
using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class TrendRepositoryDb: RepositoryDb<Trend>, ITrendRepository
  {
    public TrendRepositoryDb(DbContext data, ICache cache, ILogger<TrendRepositoryDb> logger) : base(data, cache, logger) { }
  }
}
