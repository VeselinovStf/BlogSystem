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
            PageHeaderViewModel returnModel =
                new PageHeaderViewModel()
                {
                    BackgroundImage = "home-bg.jpg",
                    HeaderTitle = "Welcome",
                    PageTitle = "BS Home Page"
                };

            return View(returnModel);
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
