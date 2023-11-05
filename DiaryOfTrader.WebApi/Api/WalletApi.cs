using DiaryOfTrader.Core.Repository;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class WalletApi : Api<Wallet, IWalletRepository>, IApi
  {
    public WalletApi(IOptions<EndPointConfiguration> config, ILogger<Api<Wallet, IWalletRepository>> logger) : base(config, logger)
    {
    }
  }
}
