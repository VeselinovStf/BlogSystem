using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BS.Web.Models;
using BS.WEB.ViewModels.ViewComponents;

namespace BS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeControllerPageViewModel returnModel =
                new HomeControllerPageViewModel()
                {
                    BackgroundImage = "home-bg.jpg",
                    HeaderTitle = "Wellcome",
                    PageTitle = "BS Home Page"
                };

            return View(returnModel);
        }

        public IActionResult About()
        {
            HomeControllerPageViewModel returnModel =
                new HomeControllerPageViewModel()
                {
                    BackgroundImage = "about-bg.jpg",
                    HeaderTitle = "About BS",
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
