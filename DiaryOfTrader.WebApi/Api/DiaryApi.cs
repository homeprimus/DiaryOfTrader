
using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class DiaryApi : Api<Diary, IDiaryRepository>, IApi
  {
    public DiaryApi(ILogger<RepositoryDb<Diary>> logger) : base(logger)
    {
    }
  }
}
