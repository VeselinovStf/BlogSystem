using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.Data.Author.Repository;
using BS.Data.BlogPostsRepository;
using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Data.Tags.Repository;
using BS.Identity.Manager.SignInManager.Wrapper.Abstract;
using BS.Identity.Manager.SignInManagerUtility;
using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Manager.UserManagerUtility;
using BS.Identity.Models;
using BS.Identity.Service.BaseIdentityUserService;
using BS.Identity.Service.BaseIdentityUserService.Abstract;
using BS.Services.BlogPostService;
using BS.Services.BlogPostService.Abstract;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.BlogPostService.ModelFactory;
using BS.Services.ModelFactory.Abstract;
using BS.Services.TagService;
using BS.Services.TagService.Abstract;
using BS.Services.TagService.ModelDTO;
using BS.Services.TagService.ModelFactory;
using BS.Web.Utilities.LocalRedirector;
using BS.Web.Utilities.LocalRedirector.Abstract;
using BS.WEB.AccountControllerValidation;
using BS.WEB.AccountControllerValidation.Abstract;
using BS.WEB.BlogPostModelFactory;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using BS.WEB.ViewModels.Tag;
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
using BS.WEB.TagModelFactory;
using BS.Data.BlogPostTag.Repository;
using BS.Data.Search.Repository;
using BS.Services.BlogSearchService.Abstract;
using BS.Services.BlogSearchService;
using BS.Service.BlogSearch.ModelFactory;
using BS.Service.BlogSearchService.DTO;
using BS.WEB.SearchModelFactory;

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

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IEntityStringIdGet<Author>, AuthorRepository>();
            services.AddScoped<IEntityIntGetId<IEnumerable<Tag>>, TagIdGetRepository>();
            services.AddScoped<IEntityRepository<Tag>, TagRepository>();
            services.AddScoped<IEntityAddReturnRepository<Tag>, TagAddReturnRepository>();
            services.AddScoped<IEntityAddRepository<BlogPostTag>, BlogPostTagRepository>();
            services.AddScoped<ISearchRepository<BlogPost>, SearchRepository>();
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<BaseIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BlogSystemEFDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserManagerWrapper<BaseIdentityUser>, UserManagerUtility>();
            services.AddScoped<ISignInManagerWrapper<BaseIdentityUser>, SignInManagerUtility>();
            services.AddScoped<IBaseIdentityUserService, BaseIdentityUserService>();
            services.AddScoped<IAccountControllerValidation, AccountControllerValidation>();
        }

        private void ConfigureAppWrapperService(IServiceCollection services)
        {
            services.AddScoped<IDateTimeWrapper, ExactDateTimeNowProvider>();
        }

        private void ConfigureAppService(IServiceCollection services)
        {
            services.AddScoped<ILocalRedirector, LocalRedirector>();
            // BlogPost
            services.AddScoped<IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>>, BlogPostListModelFactory>();
            services.AddScoped<IServiceModelFactory<BlogPostDTO, BlogPost>, Services.BlogPostService.ModelFactory.BlogPostModelFactory>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IModelFactory<BlogPostSetViewModel, IEnumerable<BlogPostDTO>>, BlogPostSetModelFactory>();
            services.AddScoped<IModelFactory<BlogPostDetailsViewModel, BlogPostDTO>, WEB.BlogPostModelFactory.BlogPostModelFactory>();
            services.AddScoped<IModelFactory<BlogPostEditViewModel, BlogPostDTO>, EditBlogPostModelFactory>();
            services.AddScoped<IModelFactory<BlogPostDeleteViewModel, BlogPostDTO>, DeleteBlogPostModelFactory>();
            //Tag
            services.AddScoped<IServiceModelFactory<TagSetDTO, IEnumerable<Tag>>, Services.TagService.ModelFactory.TagListModelFactory>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IModelFactory<TagSetViewModel, TagSetDTO> , WEB.TagModelFactory.TagListModelFactory>();
            services.AddScoped<IModelFactory<TagPageViewModel, TagDetailsDTO>, WEB.TagModelFactory.TagModelFactory>();
            services.AddScoped<IServiceModelFactory<TagDetailsDTO, Tag>, Services.TagService.ModelFactory.TagModelFactory>();
            services.AddScoped<IModelFactory<TagEditViewModel, TagDetailsDTO>, TagEditModelFactory>();
            services.AddScoped<IModelFactory<TagDeleteViewModel, TagDetailsDTO>, TagDeleteModelFactory>();
            //Search
            services.AddScoped<IServiceListModelFactory<SearchBlogPostResultDTO, IEnumerable<BlogPost>>, ResultBlogPostModelFactory>();
            services.AddScoped<IBlogSearchService, BlogSearchService>();
            services.AddScoped<IModelFactory<BlogPostSetViewModel, IEnumerable<SearchBlogPostResultDTO>>, SearchModelFactory>();


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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
