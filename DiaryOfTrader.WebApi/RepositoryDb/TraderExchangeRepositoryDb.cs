
namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class TraderExchangeRepositoryDb : RepositoryDb<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepositoryDb(DbContext data) : base(data) { }
  }
}
