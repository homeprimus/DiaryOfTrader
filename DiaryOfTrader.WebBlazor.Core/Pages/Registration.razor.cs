using DiaryOfTrader.Core.Auth;
using DiaryOfTrader.WebBlazor.Core.HttpRepository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class Registration
{
    private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();

    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    public bool ShowRegistrationErrors { get; set; }
    public IEnumerable<string>? Errors { get; set; }

    public async Task Register()
    {
        ShowRegistrationErrors = false;

        var result = await AuthenticationService.RegisterUser(_userForRegistration);
        if (!result.IsSuccessfulRegistration)
        {
            Errors = result.Errors;
            ShowRegistrationErrors = true;
        }
        else
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
