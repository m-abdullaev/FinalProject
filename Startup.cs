using System;

using FinalProject.Context;
using FinalProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinalProject
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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")).UseLazyLoadingProxies());

            services.AddIdentity<ApplicationUser, IdentityRole>(opt => 
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 4;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.ConfigureApplicationCookie(configure =>
            {
                configure.LoginPath = "/Account/Login";
                configure.AccessDeniedPath = "/Account/Login";
                configure.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                configure.SlidingExpiration = true;
            });

            services.AddControllersWithViews();
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
                    name: "default",
                    pattern: "{controller=Course}/{action=Index}");
            });
        }
    }
}
