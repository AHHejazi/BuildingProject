using Microsoft.AspNetCore.Components;

namespace Building.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("/login");
        }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("/register");
        }

        protected async void Logout()
        {
           
        }
    }
}
