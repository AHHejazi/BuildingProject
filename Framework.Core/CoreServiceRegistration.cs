using Framework.Core.Caching;
using Framework.Core.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Globalization;

namespace App.Persistence
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMemoryCache();

            // Configure supported cultures and localization options
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new[]
                                                {
                                                        new CultureInfo("ar"), new CultureInfo("en"),
                                                        new CultureInfo("en-GB"), new CultureInfo("ar-SA")
                                                    };

                    // State what the default culture for your application is. This will be used if no specific culture
                    // can be determined for a given request.
                    options.DefaultRequestCulture = new RequestCulture("en-GB", "en-GB");

                    // You must explicitly state which cultures your application supports.
                    // These are the cultures the app supports for formatting numbers, dates, etc.
                    options.SupportedCultures = supportedCultures;

                    // These are the cultures the app supports for UI strings, i.e. we have localized resources for.
                    options.SupportedUICultures = supportedCultures;
                });

            services.AddLocalization();


            return services;    
        }


        public static void ConfigureCommonRequestPipeline(this IApplicationBuilder app)
        {
           


            app.UseGlobalization(); // Common Framework Globalization Middleware
          

        }
    }
}
