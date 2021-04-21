using App.Identity.Identity;
using App.Identity.Models;
using App.Identity.Services;
using Application.App.Contracts.Identity;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BuildingIdentityDbContext>(options =>
                      options.UseSqlServer(
                          configuration.GetConnectionString("BuildingConnectionString")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BuildingIdentityDbContext>();


            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddBlazoredLocalStorage();

            services.AddAuthorizationCore();
            //services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddAuthentication("Identity.Application")
               .AddCookie();


        }
    }
}
