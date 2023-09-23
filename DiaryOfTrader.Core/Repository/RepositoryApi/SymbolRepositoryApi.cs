
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class SymbolRepositoryApi : RepositoryApi<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryApi(EndPointConfiguration config, HttpClient client, ILogger<RepositoryApi<Symbol>> logger) : base(config, client, logger)
    {
    }
  }
}
