﻿
namespace DiaryOfTrader.WebApi.Auth
{
  public interface ITokenService
  {
    string GetToken(string key, string issue, Trader trader);
  }
}
