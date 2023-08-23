namespace DiaryOfTrader.Core.Interfaces.Repository
{
  public interface ITraderRepository : IRepository<Trader>
  {
    Task<Trader> Search(string user, string password);
  }
}
