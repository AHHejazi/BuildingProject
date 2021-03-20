using Application.App.Contracts.Identity;
using Application.App.Models.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AuthenticationService> _logger;
        public readonly NavigationManager _navigationManager;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public AuthenticationService(SignInManager<IdentityUser> signInManager,
            ILogger<AuthenticationService> logger,
            UserManager<IdentityUser> userManager, NavigationManager navigationManager,
            IDataProtectionProvider dataProtectionProvider)
        {
            _userManager = userManager;
            _navigationManager = navigationManager;
            _dataProtectionProvider = dataProtectionProvider;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            bool isDone;
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "SignIn");

                    var data = $"{user.Id}|{token}";

                    var parsedQuery = System.Web.HttpUtility.ParseQueryString(new Uri(_navigationManager.Uri).Query);

                    var returnUrl = parsedQuery["returnUrl"];

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        data += $"|{returnUrl}";
                    }

                    var protector = _dataProtectionProvider.CreateProtector("SignIn");

                    var pdata = protector.Protect(data);

                    _navigationManager.NavigateTo("/account/signinactual?t=" + pdata, forceLoad: true);

                    isDone = true;
                }
                else
                {
                    isDone = false; ;
                }
                return isDone;
            }
            catch (Exception e)
            {
                isDone = false;
                _logger.LogInformation(e.ToString());
                return isDone;
            }
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            bool isDone;
            try
            {
                var user = new IdentityUser { UserName = userName, Email = email };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    _navigationManager.NavigateTo("/", true);
                    isDone = true;
                }
                else
                {
                    isDone = false;
                }
                return isDone;
            }
            catch (Exception e)
            {
                isDone = false;
                _logger.LogInformation(e.ToString());
                return isDone;
            }

        }
    }
}
