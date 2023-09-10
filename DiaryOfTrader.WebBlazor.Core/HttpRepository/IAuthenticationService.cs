using DiaryOfTrader.Core.Auth;

namespace DiaryOfTrader.WebBlazor.Core.HttpRepository;

public interface IAuthenticationService
{
    Task<ResponseDto> RegisterUser(UserForRegistrationDto userForRegistrationDto);
    // Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
    Task Logout();
    // Task<string> RefreshToken();
}
