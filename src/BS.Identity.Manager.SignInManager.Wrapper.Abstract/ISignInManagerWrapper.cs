using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.Identity.Manager.SignInManager.Wrapper.Abstract
{
    public interface ISignInManagerWrapper<T>
    {
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure);

        Task SignOutAsync();

        bool IsSignedIn(ClaimsPrincipal user);
    }
}
