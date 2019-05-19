using BS.WEB.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.ViewComponents.HomeController
{
    public class PageHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PageHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                PageHeaderViewModel returnModel =
                    new PageHeaderViewModel()
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
