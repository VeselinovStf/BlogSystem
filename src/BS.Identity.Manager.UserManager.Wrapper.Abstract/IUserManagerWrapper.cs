using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.Identity.Manager.UserManager.Wrapper.Abstract
{
    public interface IUserManagerWrapper<T>
    {
     

        Task<T> FindByEmailAsync(string email);

        Task<T> GetUserAsync(ClaimsPrincipal user);

     

        Task<IList<string>> GetRolesAsync(T user);

        
    }
}
