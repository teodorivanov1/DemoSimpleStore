using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleStoreWeb.Data;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Extensions;

namespace SimpleShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(
                options => options.Password.UseWeakPasswords())
                .AddEntityFrameworkStores<SimpleStoreDbContext>();
            services.AddAuthentication().AddCookie();

            services.AddDbContext<SimpleStoreDbContext>();
            services.AddRepositories();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(configuration =>
            {
                configuration.MapControllerRoute(
                    "Fallback", 
                    "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });

                configuration.MapRazorPages();
            });
        }
    }
}
