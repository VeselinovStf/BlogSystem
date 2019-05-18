﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.Data.EFContext;
using BS.Identity.Manager.SignInManager.Wrapper.Abstract;
using BS.Identity.Manager.SignInManagerUtility;
using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Manager.UserManagerUtility;
using BS.Identity.Models;
using BS.Identity.Service.BaseIdentityUserService;
using BS.Identity.Service.BaseIdentityUserService.Abstract;
using DateTimeProvider;
using DateTimeWrapper.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ConfigureDb(services);
            ConfigureIdentity(services);
            ConfigureAppService(services);
            ConfigureAppWrapperService(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void ConfigureDb(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<BlogSystemEFDbContext>(options =>
                 options.UseSqlServer(
                   Configuration.GetConnectionString("DevelopmentConnectionString")));
            }
            else
            {
                services.AddDbContext<BlogSystemEFDbContext>(options =>
                 options.UseSqlServer(
                   Configuration.GetConnectionString("ProductionConnectionString")));
            }
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<BaseIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BlogSystemEFDbContext>()
                .AddDefaultTokenProviders();
        }

        private void ConfigureAppWrapperService(IServiceCollection services)
        {
            services.AddScoped<IDateTimeWrapper, ExactDateTimeNowProvider>();
        }

        private void ConfigureAppService(IServiceCollection services)
        {
            services.AddScoped<IUserManagerWrapper<BaseIdentityUser>, UserManagerUtility>();
            services.AddScoped<ISignInManagerWrapper<BaseIdentityUser>, SignInManagerUtility>();
            services.AddScoped<IBaseIdentityUserService, BaseIdentityUserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
