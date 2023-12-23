
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class SymbolRepositoryApi : RepositoryApi<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<Symbol>> logger) : base(config, client, logger)
    {
    }
  }
}
