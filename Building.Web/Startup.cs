using Application.App;
using Application.App.Contracts;
using App.Persistence;
using Building.Web.Data;
using Building.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using Application.App.Services.Projects;
using Application.App.Services.Buildings;
using Application.App.Contracts.Persistence;
using App.Persistence.Repositories;
using App.Identity;
using Application.App.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using System.Collections.Generic;
using System.Reflection;

namespace Building.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor(c => c.DetailedErrors = true);
            services.AddTransient<IValidator<ProjectDto>, ProjectValidator>();
            //services.AddTransient<IValidator<BuildingDto>, BuildingValidator>();
            services.AddValidatorsFromAssemblyContaining<ProjectDto>();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCoreServices();
            services.AddApplicationServices();
            //services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices(Configuration);
            services.AddIdentityServices(Configuration);
            services.AddScoped<TokenProvider>();
            services.AddHttpContextAccessor();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.ConfigureCommonRequestPipeline();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
