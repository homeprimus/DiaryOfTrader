using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class DiaryApi : Api<Diary, IDiaryRepository>, IApi
  {
    public DiaryApi(IOptions<EndPointConfiguration> config, ILogger<Api<Diary, IDiaryRepository>> logger) : base(config, logger)
    {
    }
  }
}
