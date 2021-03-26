using Application.App.Contracts.Persistence;
using App.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Application.Contracts.Persistence;

namespace App.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BuildingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BuildingConnectionString")), ServiceLifetime.Transient);

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();

            return services;    
        }
    }
}
