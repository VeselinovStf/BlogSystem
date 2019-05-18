using BS.Identity.Manager.SignInManager.Wrapper.Abstract;
using BS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.Identity.Manager.SignInManagerUtility
{
    public class SignInManagerUtility : ISignInManagerWrapper<BaseIdentityUser>
    {
        private readonly SignInManager<BaseIdentityUser> _signInManager;

        public SignInManagerUtility(SignInManager<BaseIdentityUser> signInManager)
        {
            this._signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task SignInAsync(BaseIdentityUser user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: lockoutOnFailure);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RefreshSignInAsync(BaseIdentityUser user)
        {
            await this._signInManager.RefreshSignInAsync(user);
        }

        public bool IsSignedIn(ClaimsPrincipal user)
        {
            return this._signInManager.IsSignedIn(user);
        }

        public async Task<ClaimsPrincipal> CreateUserPrincipalAsync(BaseIdentityUser user)
        {
            return await this._signInManager.CreateUserPrincipalAsync(user);
        }
    }
}
