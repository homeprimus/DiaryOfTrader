using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class SymbolApi : Api<Symbol, ISymbolRepository>, IApi
  {
    public SymbolApi(IOptions<EndPointConfiguration> config, ILogger<Api<Symbol, ISymbolRepository>> logger) : base(config, logger)
    {
    }
  }
}
