using BS.Identity.Manager.SignInManager.Wrapper.Abstract;
using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.ViewComponents.Menu
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly ISignInManagerWrapper<BaseIdentityUser> signInManager;
        private readonly IUserManagerWrapper<BaseIdentityUser> userManager;
        

        public MainMenuViewComponent(
             ISignInManagerWrapper<BaseIdentityUser> signInManager,
             IUserManagerWrapper<BaseIdentityUser> userManager
             )
        {
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (this.signInManager.IsSignedIn(HttpContext.User))
            {
                var user = await this.userManager.GetUserAsync(HttpContext.User);            
                var role = await this.userManager.GetRolesAsync(user);

                if (role.Contains("Administrator"))
                {
                    return View("AdminMenu");
                }

                return View("GuestMenu");
            }
            else
            {
                return View("GuestMenu");
            }
        }
    }
}
