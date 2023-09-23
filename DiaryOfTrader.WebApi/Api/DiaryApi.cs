using DiaryOfTrader.Core.Repository;

namespace DiaryOfTrader.WebApi.Api
{
  public class DiaryApi : Api<Diary, IDiaryRepository>, IApi
  {
    public DiaryApi(EndPointConfiguration config, ILogger<Api<Diary, IDiaryRepository>> logger) : base(config, logger)
    {
    }
  }
}
