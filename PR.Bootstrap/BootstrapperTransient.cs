using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PR.Data;
using PR.Interfaces;
using PR.Bootstrap.Automapper;
using PR.Entities;
using PR.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using PR.Business.Services;

namespace PR.Bootstrap
{
    public static class ExtensionRepositoryConfiguration
    {
        public static void RegisterDomainModels(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PRDbContext>(options =>
             {
                 options.UseMySql(connection);
             });
            services.AddSingleton(typeof(string), connection);
            services.AddSingleton<Interfaces.IMapper, PRAutoMapper>();


            #region Repositories
            services.AddScoped<IRepositoryAsync<User>, UserRepository>();
            #endregion Repositories

            #region Services
            services.AddScoped<IRepositoryAsync<User>, UserRepository>();
            services.AddTransient<UserService>();
            //services.AddSingleton<RoleManager<IdentityRole>>();
            services.AddScoped<IRepository<Report>, ReportRepository>();
            services.AddScoped<IRepository<ReportStatus>, BasicRepository<ReportStatus>>();

            #endregion Repositories

            #region Services
            services.AddTransient<ReportService>();

            services.AddTransient<ReportStatusService>(); 
            services.AddTransient<UserService>();
            services.AddTransient<ReportAssistantService>();
            #endregion Services
        }
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<PRDbContext>()
            .AddRoleStore<PRDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
