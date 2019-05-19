using BS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Identity.Service.BaseIdentityUserService.Abstract
{
    public interface IBaseIdentityUserService
    {
        
        Task<SignInResult>  PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure);
        Task<BaseIdentityUser> FindByEmailAsync(string email);
        Task<IList<string>> GetRolesAsync(BaseIdentityUser user);
        Task SignOutAsync();
        Task<bool> IsEmailConfirmedAsync(BaseIdentityUser user);
    }
}
