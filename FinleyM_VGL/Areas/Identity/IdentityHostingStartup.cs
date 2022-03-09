using System;
using FinleyM_VGL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FinleyM_VGL.Areas.Identity.IdentityHostingStartup))]
namespace FinleyM_VGL.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddIdentity<IdentityUser, IdentityRole>(options => {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireDigit = true;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = true;
                    })
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<IdentityContext>();

                services.Configure<IdentityOptions>(options =>
                {
                    //options.Password.RequiredLength = 4;

                    //options.Password.RequireDigit = true;

                    //options.User.RequireUniqueEmail = true;
                });
            });
        }
    }
}