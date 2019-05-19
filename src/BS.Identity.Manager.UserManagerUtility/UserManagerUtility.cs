using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.Identity.Manager.UserManagerUtility
{
    public class UserManagerUtility : IUserManagerWrapper<BaseIdentityUser>
    {
        private readonly UserManager<BaseIdentityUser> _userManager;

        public UserManagerUtility(UserManager<BaseIdentityUser> userManager)
        {
            this._userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

       

        public async Task<BaseIdentityUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }


        public async Task<BaseIdentityUser> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }



        public async Task<IList<string>> GetRolesAsync(BaseIdentityUser user)
        {
            return await this._userManager.GetRolesAsync(user);
        }

 
    }
}
