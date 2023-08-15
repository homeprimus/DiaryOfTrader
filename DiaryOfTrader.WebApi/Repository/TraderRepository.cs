namespace DiaryOfTrader.WebApi.Repository
{
  public class TraderRepository : Repository<Trader>, ITraderRepository
  {
    public TraderRepository(DbContext data) : base(data)
    {
    }
    public async Task<Trader> Search(string user, string password)
    {
      return await Entity.Where(e => e.Name == user && e.Password == password).FirstOrDefaultAsync();
    }
  }
}
