using DiaryOfTrader.Core.Auth;
using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiaryOfTrader.WebApi.Api
{
  public class TraderApi : Api<Trader, ITraderRepository>
  {
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
      
      application.MapPost("/register",
        [AllowAnonymous] async ([FromBody] UserForRegistrationDto userForRegistrationDto,
          ITraderRepository traderRepository) =>
        {
          var result = await traderRepository.RegisterUser(userForRegistrationDto);
          if (!result.IsSuccessfulRegistration) return Results.BadRequest(result);
          return Results.Ok(result);
        }
      );
    }
  }
}
