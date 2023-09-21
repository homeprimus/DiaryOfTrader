
using DiaryOfTrader.Core.Repository.RepositoryDb;
using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderApi : Api<Trader, ITraderRepository>
  {
    public TraderApi(ILogger<RepositoryDb<Trader>> logger) : base(logger)
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
