using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PR.Data;
using PR.Entities;

[assembly: HostingStartup(typeof(PR.Web.Areas.Identity.IdentityHostingStartup))]
namespace PR.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<PRDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("DefaultConnection")));
                
                IdentityBuilder idb= services.AddDefaultIdentity<User>();
                idb.AddRoles<IdentityRole>();
                idb.AddRoleManager<RoleManager<IdentityRole>>();
                idb.AddEntityFrameworkStores<PRDbContext>();
                //idb.AddRoleStore<PRDbContext>();
                
              
            });
        }
    }
}