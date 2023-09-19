
using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class DiaryRepositoryDb : RepositoryDb<Diary>, IDiaryRepository
  {
    public DiaryRepositoryDb(DbContext data, ICache cache) : base(data, cache)
    {
    }
  }
}
