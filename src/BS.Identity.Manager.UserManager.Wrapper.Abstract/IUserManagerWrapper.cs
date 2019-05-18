using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.Identity.Manager.UserManager.Wrapper.Abstract
{
    public interface IUserManagerWrapper<T>
    {
        Task<IdentityResult> CreateAsync(T user, string password);

        Task AddToRoleAsync(T user, string baseRole);

        Task<T> FindByEmailAsync(string email);

        Task<bool> IsEmailConfirmedAsync(T user);

        Task<T> GetUserAsync(ClaimsPrincipal user);

        string GetUserId(ClaimsPrincipal user);

        Task<bool> HasPasswordAsync(T user);

        Task<IdentityResult> ChangePasswordAsync(T user, string oldPassword, string newPassword);

        Task<bool> CheckPasswordAsync(T user, string password);

        Task<IdentityResult> DeleteAsync(T user);

        Task<string> GetUserIdAsync(T user);

        Task<string> GetEmailAsync(T user);

        Task<IdentityResult> SetEmailAsync(T user, string email);

        Task<string> GetPhoneNumberAsync(T user);

        Task<IdentityResult> SetPhoneNumberAsync(T user, string phoneNumber);

        string GetUserName(ClaimsPrincipal user);

        Task<IList<string>> GetRolesAsync(T user);

        Task RemoveFromRoleAsync(T userId, string baseRole);
    }
}
