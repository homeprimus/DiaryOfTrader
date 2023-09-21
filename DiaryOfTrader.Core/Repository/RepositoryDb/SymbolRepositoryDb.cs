using DiaryOfTrader.Core.Interfaces.Cache;
using Microsoft.Extensions.Logging;

namespace DiaryOfTrader.Core.Repository.RepositoryDb
{
  public class SymbolRepositoryDb : RepositoryDb<Symbol>, ISymbolRepository
  {
    public SymbolRepositoryDb(DbContext data, ICache cache, ILogger<SymbolRepositoryDb> logger) : base(data, cache, logger) { }
  }
}
