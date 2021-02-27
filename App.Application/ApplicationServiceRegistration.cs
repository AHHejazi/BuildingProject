using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.App
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ILookupServices, LookupServices>();
            services.AddTransient<IProjectService,ProjectService>();
            return services;
        }
    }
}
