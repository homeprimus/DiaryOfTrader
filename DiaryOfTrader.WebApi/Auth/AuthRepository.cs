
namespace DiaryOfTrader.WebApi.Auth
{
  public class AuthRepository : IAuthRepository
  {
    public UserDto GetUser(UserModel model)
    {
     return new UserDto("", "");
    }
  }
}
