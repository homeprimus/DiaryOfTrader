using DiaryOfTrader.Core.Interfaces.Cache;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class SymbolRepositoryDb : RepositoryDb<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryDb(DbContext data, ICache cache) : base(data, cache) { }
  }
}
