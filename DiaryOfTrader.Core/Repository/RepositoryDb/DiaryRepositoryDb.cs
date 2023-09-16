
namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class DiaryRepositoryDb : RepositoryDb<Diary>, IDiaryRepository
  {
    public DiaryRepositoryDb(DbContext data) : base(data)
    {
    }
  }
}
