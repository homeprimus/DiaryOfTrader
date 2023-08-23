using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class TraderRepositoryApi : RepositoryApi<Trader>, ITraderRepository
  {
    public TraderRepositoryApi(string root) : base(root)
    {
    }

    public Task<Trader> Search(string user, string password)
    {
      throw new NotImplementedException();
    }
  }
}
