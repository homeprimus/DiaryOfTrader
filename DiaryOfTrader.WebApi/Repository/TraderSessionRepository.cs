
using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class TraderSessionRepository: Repository<TraderSession>, ITraderSessionRepository
  {
    public TraderSessionRepository(DbContext data) : base(data) { }
  }
}
