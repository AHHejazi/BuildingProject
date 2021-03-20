using Application.App.Contracts.Identity;
using Domain.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace GeneralIdentity.App.Components.Identity
{
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var result = await AuthenticationService.AuthenticateAsync(LoginViewModel.Email, LoginViewModel.Password);

            if (result == false)
            {
                Message = "Username/password combination unknown";
            }
        }

    }
}
