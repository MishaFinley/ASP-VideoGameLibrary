using FinleyM_VGL.Data;
using FinleyM_VGL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace FinleyM_VGL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<VideoGameContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("VideoGameDB"));
            });
            services.AddTransient<IDAL, GameListDAL>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "Search/{key}",
                    defaults: new {controller = "home", action = "Search"}
                    );
                endpoints.MapControllerRoute(
                    name: "add",
                    pattern: "Add",
                    defaults: new {controller= "home", action = "AddGame"}
                    );
                endpoints.MapControllerRoute(
                    name: "edit",
                    pattern: "Edit/{ID}",
                    defaults: new { controller = "home", action = "EditGame" }
                    );
                endpoints.MapControllerRoute(
                    name: "remove",
                    pattern: "Remove/{ID}",
                    defaults: new { controller = "home", action = "RemoveGame" }
                    );
                endpoints.MapControllerRoute(
                    name: "loan",
                    pattern: "Loan/{ID}",
                    defaults: new {controller = "home", action = "Loan"}
                    );
                endpoints.MapControllerRoute(
                    name: "return",
                    pattern: "Return/{ID}",
                    defaults: new {controller = "home", action = "Return"}
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
