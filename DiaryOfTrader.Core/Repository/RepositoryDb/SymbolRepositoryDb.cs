
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class SymbolRepositoryDb : RepositoryDb<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryDb(DbContext data) : base(data) { }
  }
}
