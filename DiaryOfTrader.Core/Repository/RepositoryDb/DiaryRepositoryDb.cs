using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class DiaryRepositoryDb : RepositoryDb<Diary>, IDiaryRepository
  {
    public DiaryRepositoryDb(DbContext data, ICache cache, ILogger<DiaryRepositoryDb> logger) : base(data, cache, logger)
    {
    }
  }
}
