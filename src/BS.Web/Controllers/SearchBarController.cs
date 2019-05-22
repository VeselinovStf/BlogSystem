using BS.Data.EFContext;
using BS.Service.BlogSearchService.DTO;
using BS.Services.BlogSearchService.Abstract;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using BS.WEB.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.Controllers
{
    public class SearchBarController : Controller
    {
        private readonly IBlogSearchService searchService;
        private readonly IModelFactory<BlogPostSetViewModel, IEnumerable<SearchBlogPostResultDTO>> modelFactory;
        private readonly ILogger<SearchBarController> logger;

        public SearchBarController(
            IBlogSearchService searchService,
            IModelFactory<BlogPostSetViewModel, IEnumerable<SearchBlogPostResultDTO>> modelFactory,
            ILogger<SearchBarController> logger)
        {
        
            this.searchService = searchService;
            this.modelFactory = modelFactory;
            this.logger = logger;
        }

        public async Task<JsonResult> Search(string Key)
        {
            try
            {
                var serviceCall = await this.searchService.GetSearchResults(Key);

                return Json(serviceCall);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return Json("Search bar is not functional.");
            }            
          
        }

        public async Task<IActionResult> Find(string Key)
        {
            try
            {
                var serviceCall = await this.searchService.GetFindResult(Key);

                var model = this.modelFactory.Create(serviceCall);

                model.BackgroundImage = "home-bg.jpg";
                model.HeaderTitle = "Search Results";
                model.PageTitle = "Search";

                this.logger.LogInformation("Search displays found result.");

                return View(model);


            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
        }
    }

  
}
