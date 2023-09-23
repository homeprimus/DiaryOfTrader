using DiaryOfTrader.Core.Repository;

namespace DiaryOfTrader.WebApi.Api
{
  public class SymbolApi : Api<Symbol, ISymbolRepository>, IApi
  {
    public SymbolApi(EndPointConfiguration config, ILogger<Api<Symbol, ISymbolRepository>> logger) : base(config, logger)
    {
    }
  }
}
