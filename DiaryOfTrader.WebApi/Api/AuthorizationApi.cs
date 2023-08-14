using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;

namespace DiaryOfTrader.WebApi.Api
{
  public class AuthorizationApi : IApi
  {
    public void Register(WebApplication application)
    {
      application.MapGet("/login", [AllowAnonymous]
        async (HttpContext context, ITokenService tokenService, IAuthRepository userRepository) =>
        {
          UserModel userModel = new()
          {
            UserName = context.Request.Query["username"],
            Password = context.Request.Query["password"],
          };
          var userDto = userRepository.GetUser(userModel);
          if (userDto == null) return Results.Unauthorized();
          var token = tokenService.GetToken(application.Configuration["Jwt:Key"],
            application.Configuration["Jwt:Issuer"], userDto);
          return Results.Ok(token);
        }
      );
    }
  }
}
