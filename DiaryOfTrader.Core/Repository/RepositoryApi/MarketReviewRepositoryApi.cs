﻿
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.Repository.RepositoryApi
{
  public class MarketReviewRepositoryApi : RepositoryApi<MarketReview>, IMarketReviewRepository
  {
    public MarketReviewRepositoryApi(IOptions<EndPointConfiguration> config, HttpClient client, ILogger<RepositoryApi<MarketReview>> logger) : base(config, client, logger)
    {
    }
  }
}
