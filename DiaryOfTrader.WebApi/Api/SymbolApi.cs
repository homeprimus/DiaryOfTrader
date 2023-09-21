using DiaryOfTrader.Core.Repository.RepositoryDb;

namespace DiaryOfTrader.WebApi.Api
{
  public class SymbolApi : Api<Symbol, ISymbolRepository>, IApi
  {
    public SymbolApi(ILogger<RepositoryDb<Symbol>> logger) : base(logger)
    {
    }
  }
}
