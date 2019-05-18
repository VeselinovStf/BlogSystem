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

        public async Task AddToRoleAsync(BaseIdentityUser user, string baseRole)
        {
            await _userManager.AddToRoleAsync(user, baseRole);
        }

        public async Task<IdentityResult> CreateAsync(BaseIdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<BaseIdentityUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsEmailConfirmedAsync(BaseIdentityUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<BaseIdentityUser> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        public string GetUserId(ClaimsPrincipal user)
        {
            return this._userManager.GetUserId(user);
        }

        public async Task<bool> HasPasswordAsync(BaseIdentityUser user)
        {
            return await _userManager.HasPasswordAsync(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(BaseIdentityUser user, string oldPassword, string newPassword)
        {
            return await this._userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<bool> CheckPasswordAsync(BaseIdentityUser user, string password)
        {
            return await this._userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> DeleteAsync(BaseIdentityUser user)
        {
            return await this._userManager.DeleteAsync(user);
        }

        public async Task<string> GetUserIdAsync(BaseIdentityUser user)
        {
            return await this._userManager.GetUserIdAsync(user);
        }

        public async Task<string> GetEmailAsync(BaseIdentityUser user)
        {
            return await this._userManager.GetEmailAsync(user);
        }

        public async Task<IdentityResult> SetEmailAsync(BaseIdentityUser user, string email)
        {
            return await this._userManager.SetEmailAsync(user, email);
        }

        public async Task<string> GetPhoneNumberAsync(BaseIdentityUser user)
        {
            return await this._userManager.GetPhoneNumberAsync(user);
        }

        public async Task<IdentityResult> SetPhoneNumberAsync(BaseIdentityUser user, string phoneNumber)
        {
            return await this._userManager.SetPhoneNumberAsync(user, phoneNumber);
        }

        public string GetUserName(ClaimsPrincipal user)
        {
            return this._userManager.GetUserName(user);
        }

        public async Task<IList<string>> GetRolesAsync(BaseIdentityUser user)
        {
            return await this._userManager.GetRolesAsync(user);
        }

        public async Task RemoveFromRoleAsync(BaseIdentityUser userId, string baseRole)
        {
            await this._userManager.RemoveFromRoleAsync(userId, baseRole);
        }
    }
}
