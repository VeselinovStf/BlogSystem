using BS.Identity.Manager.SignInManager.Wrapper.Abstract;
using BS.Identity.Models;
using BS.WEB.ViewModels.BlogPost;
using BS.WEB.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.ViewComponents.BlogPost
{
    public class BlogPostSetViewComponent : ViewComponent
    {
        private readonly ISignInManagerWrapper<BaseIdentityUser> signInManager;

        public BlogPostSetViewComponent(ISignInManagerWrapper<BaseIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<BlogPostViewModel>  model)
        {
            if (ModelState.IsValid)
            {
                BlogPostViewComponentModel returnModel = new BlogPostViewComponentModel()
                {
                    Posts = model
                };

                if (this.signInManager.IsSignedIn(HttpContext.User))
                {
                    returnModel.IsPublic = false;
                }
                else
                {
                    returnModel.IsPublic = true;
                }

                return View("BlogPostSet", returnModel);
            }

            return View();

        }
    }
}
