namespace DiaryOfTrader.WebApi.Interface
{
  public interface ITraderRepository : IRepository<Trader>
  {
    Task<Trader> Search(string user, string password);
  }
}
