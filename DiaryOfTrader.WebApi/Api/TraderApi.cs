
using DiaryOfTrader.Core.Repository;
using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderApi : Api<Trader, ITraderRepository>
  {
    public TraderApi(IOptions<EndPointConfiguration> config, ILogger<Api<Trader, ITraderRepository>> logger) : base(config, logger)
    {
    }

    public override void Register(WebApplication application)
    {
      base.Register(application);
      application.MapGet("/login",
        [AllowAnonymous] async ([FromQuery] string user, [FromQuery] string password, ITokenService tokenService,
          ITraderRepository traderRepository) =>
        {
          var trader = await traderRepository.Search(user, password);
          if (trader == null) return Results.Unauthorized();

          var token = tokenService.GetToken(application.Configuration["Jwt:Key"],
            application.Configuration["Jwt:Issuer"], trader);
          return Results.Ok(token);
        }
      );
    }

  }
}
