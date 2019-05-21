using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.ViewComponents.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
    {

        public SearchBarViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SearchBar");
        }
    }
}
