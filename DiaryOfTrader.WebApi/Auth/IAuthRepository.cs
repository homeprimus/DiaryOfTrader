namespace DiaryOfTrader.WebApi.Auth
{
  public interface IAuthRepository
  {
    UserDto GetUser(UserModel model);
  }
}
