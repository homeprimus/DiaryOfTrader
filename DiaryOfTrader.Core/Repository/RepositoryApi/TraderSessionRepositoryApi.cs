
namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderSessionRepositoryApi : RepositoryApi<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepositoryApi(string root) : base(root)
    {
    }
  }
}
