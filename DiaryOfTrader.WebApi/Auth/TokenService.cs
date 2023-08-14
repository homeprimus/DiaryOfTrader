using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DiaryOfTrader.WebApi.Auth
{
  public class TokenService: ITokenService
  {
    private TimeSpan expiryDuradion = new(0, 30, 0);

    public string GetToken(string key, string issue, UserDto user)
    {
      var claims = new[]
      {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
      };
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
      var credintals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
      var tokenDescriptor = new JwtSecurityToken(issue, issue, claims, expires: DateTime.Now.Add(expiryDuradion),
        signingCredentials: credintals);
      return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
  }
}
