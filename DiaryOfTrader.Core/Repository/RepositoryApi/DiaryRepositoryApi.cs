
namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class DiaryRepositoryApi : RepositoryApi<Diary>, IDiaryRepository
  {
    public DiaryRepositoryApi(string root) : base(root)
    {
    }
  }
}
