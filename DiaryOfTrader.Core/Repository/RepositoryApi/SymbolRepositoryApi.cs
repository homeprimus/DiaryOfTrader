
namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class SymbolRepositoryApi : RepositoryApi<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryApi(string root) : base(root)
    {
    }
  }
}
