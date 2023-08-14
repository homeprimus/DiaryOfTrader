
using DiaryOfTrader.WebApi.Interface;

namespace DiaryOfTrader.WebApi.Repository
{
  public class SymbolRepository : Repository<Symbol>, ISymbolRepository
  {
    public SymbolRepository(DbContext data) : base(data) { }
  }
}
