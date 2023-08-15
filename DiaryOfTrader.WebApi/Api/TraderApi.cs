// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using DiaryOfTrader.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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
    }

  }
}
