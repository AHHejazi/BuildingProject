using Application.App.Services.Common;
using Application.App.Services.Buildings;
using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.App.Services.Supplies;
using Application.App.Services.Components;

namespace Application.App
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ILookupServices, LookupServices>();
            services.AddTransient<IProjectService,ProjectService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<AppSettingsService>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IComponentService, ComponentService>();
            services.AddTransient<ISuppliesService, SuppliesService>();

            return services;
        }
    }
}
