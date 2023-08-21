using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages
{
    public partial class CustomNotFound
	{
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public void NavigateToHome()
		{
			NavigationManager.NavigateTo("/");
		}
	}
}
