using BS.Data.EFContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.Controllers
{
    public class SearchBarController : Controller
    {
        private readonly BlogSystemEFDbContext cont;

        public SearchBarController(BlogSystemEFDbContext cont)
        {
            this.cont = cont;
        }

        public async Task<JsonResult> searchresult(string prefixtext)
        {
            var query =  await this.cont.Tags
                .Where(t => t.Name.Contains(prefixtext))
                .Select(t => t.Name).Distinct().ToListAsync();

            return Json(query);
        }
    }
}
