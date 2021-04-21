using App.Identity.Models;
using Application.App.Contracts.Identity;
using Application.App.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AuthenticationService> _logger;
        public readonly NavigationManager _navigationManager;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public AuthenticationService(SignInManager<ApplicationUser> signInManager,
            ILogger<AuthenticationService> logger,
            UserManager<ApplicationUser> userManager, NavigationManager navigationManager,
            IDataProtectionProvider dataProtectionProvider)
        {
            _userManager = userManager;
            _navigationManager = navigationManager;
            _dataProtectionProvider = dataProtectionProvider;
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

        public async Task<BaseResponse> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
         
            var baseResponse = new BaseResponse();
            try
            {
                var user = new ApplicationUser { UserName = userName, Email = email };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    _navigationManager.NavigateTo("/", true);
                    return baseResponse;
                }
                else
                {
                    baseResponse.Success = false;
                    baseResponse.ValidationErrors = new List<string>();
                    baseResponse.ValidationErrors.Add(string.Join(";",result.Errors.Select(x=>x.Description).ToList()));
                }
                return baseResponse;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                baseResponse.Success = false;
                baseResponse.ValidationErrors = new List<string>();
                baseResponse.ValidationErrors.Add(e.ToString());
                return baseResponse;
            }

        }
    }
}
