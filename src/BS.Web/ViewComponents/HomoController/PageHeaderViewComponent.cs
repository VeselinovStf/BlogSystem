using BS.WEB.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.ViewComponents.HomoController
{
    public class PageHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(HomeControllerPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                HomeControllerPageViewModel returnModel =
                    new HomeControllerPageViewModel()
                    {
                        BackgroundImage = model.BackgroundImage,
                        HeaderTitle = model.HeaderTitle,
                        PageTitle = model.PageTitle
                    };

                return View("PageHeader", returnModel);
            }

            return View();

        }
    }
}
