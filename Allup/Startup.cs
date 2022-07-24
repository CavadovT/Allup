using Allup.DAL;
using Allup.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<User, IdentityRole>(option => {
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase= true;
                option.Password.RequireUppercase= true;
                option.Password.RequireNonAlphanumeric= true;
                option.Password.RequireDigit= true;

                option.User.RequireUniqueEmail= true;
                
                option.Lockout.MaxFailedAccessAttempts= 3;
                option.Lockout.AllowedForNewUsers= true;
                option.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);

                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name:"default",
                  pattern:"{controller=home}/{action=index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
