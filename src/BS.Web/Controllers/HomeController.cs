using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BS.Web.Models;
using BS.WEB.ViewModels.ViewComponents;
using BS.Services.BlogPostService.Abstract;
using BS.WEB.ModelFactory.Abstract;
using BS.Services.BlogPostService.ModelDTO;
using BS.WEB.ViewModels.BlogPost;
using Microsoft.Extensions.Logging;

namespace BS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService blogPostService;
        private readonly IModelFactory<BlogPostSetViewModel, IEnumerable<BlogPostDTO>> blogPostListModelFactory;
        private readonly ILogger<HomeController> logger;

        public HomeController(
            IBlogPostService blogPostService,
            IModelFactory<BlogPostSetViewModel,
            IEnumerable<BlogPostDTO>> blogPostListModelFactory,
            ILogger<HomeController> logger)
        {
            this.blogPostService = blogPostService;
            this.blogPostListModelFactory = blogPostListModelFactory;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var serviceCall = await this.blogPostService.GetAll();

                var model = this.blogPostListModelFactory.Create(serviceCall);

                model.BackgroundImage = "home-bg.jpg";
                model.HeaderTitle = "Welcome";
                model.PageTitle = "BS Home Page";

                this.logger.LogInformation("Displaying All Blog Posts.");

                return View(model);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
          
        }

        public IActionResult About()
        {
            PageHeaderViewModel returnModel =
                new PageHeaderViewModel()
                {
                    BackgroundImage = "about-bg.jpg",
                    HeaderTitle = "About BS",
                    PageTitle = "BS About Page"
                };

            return View(returnModel);
        }

        public IActionResult Contact()
        {
            PageHeaderViewModel returnModel =
               new PageHeaderViewModel()
               {
                   BackgroundImage = "contact-bg.jpg",
                   HeaderTitle = "Contact",
                   PageTitle = "BS About Page"
               };

            return View(returnModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
