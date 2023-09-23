
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class DiaryRepositoryApi : RepositoryApi<Diary>, IDiaryRepository
  {
    public DiaryRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<Diary>> logger) : base(config, client, logger)
    {
    }
  }
}
