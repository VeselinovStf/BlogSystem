using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.Identity.Manager.SignInManager.Wrapper.Abstract
{
    public interface ISignInManagerWrapper<T>
    {
        Task SignInAsync(T user, bool isPersistent);

        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure);

        Task SignOutAsync();

        Task RefreshSignInAsync(T user);

        bool IsSignedIn(ClaimsPrincipal user);

        Task<ClaimsPrincipal> CreateUserPrincipalAsync(T user);
    }
}
