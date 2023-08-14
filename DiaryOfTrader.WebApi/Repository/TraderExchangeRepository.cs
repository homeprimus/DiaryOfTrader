
using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class TraderExchangeRepository : Repository<TraderExchange>, ITraderExchangeRepository
  {
    public TraderExchangeRepository(DbContext data) : base(data) { }
  }
}
