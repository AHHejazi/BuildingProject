using Application.App.Contracts.Identity;
using Domain.App.ViewModels;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace GeneralIdentity.App.Components.Identity
{
    public partial class Register: PageBase
    {
        public RegisterViewModel RegisterViewModel { get; set; } //= new RegisterViewModel();

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Register()
        {

        }
        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var result = await AuthenticationService.RegisterAsync(RegisterViewModel.FirstName, RegisterViewModel.LastName, RegisterViewModel.UserName, RegisterViewModel.Email, RegisterViewModel.Password);

            if (result.Success)
            {
                NavigationManager.NavigateTo("home");
            }

            StatusClass = "alert alert-danger";
            Message = result.ValidationErrors.FirstOrDefault();
        }

    }
}
