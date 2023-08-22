
namespace DiaryOfTrader.WebApi.RepositoryDb
{
  public class SymbolRepositoryDb : RepositoryDb<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryDb(DbContext data) : base(data) { }
  }
}
