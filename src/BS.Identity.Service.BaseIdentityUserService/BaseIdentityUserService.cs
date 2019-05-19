using BS.Identity.Manager.SignInManager.Wrapper.Abstract;
using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Models;
using BS.Identity.Service.BaseIdentityUserService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Identity.Service.BaseIdentityUserService
{
    public class BaseIdentityUserService : IBaseIdentityUserService
    {
        private readonly ISignInManagerWrapper<BaseIdentityUser> _signInManager;
        private readonly IUserManagerWrapper<BaseIdentityUser> _userManager;

        public BaseIdentityUserService(ISignInManagerWrapper<BaseIdentityUser> signInManager, IUserManagerWrapper<BaseIdentityUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public async Task<BaseIdentityUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetRolesAsync(BaseIdentityUser user)
        {
            return await this._userManager.GetRolesAsync(user);
        }

        public async Task<bool> IsEmailConfirmedAsync(BaseIdentityUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure);
        }

       

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
