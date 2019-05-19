using BS.Identity.Service.BaseIdentityUserService.Abstract;
using BS.WEB.AccountControllerValidation.Abstract;
using BS.WEB.ControllerValidation.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BS.WEB.AccountControllerValidation
{
    public class AccountControllerValidation : IAccountControllerValidation
    {
        private readonly IBaseIdentityUserService identityService;
       

        public const string BASE_USER_ROLE = "Administrator";

        public AccountControllerValidation(IBaseIdentityUserService identityServicer)
        {
            this.identityService = identityServicer;
            
        }

        public async Task<string> Login(string email, string password, bool rememberMe)
        {
           
                var result = await this.identityService.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var user = await this.identityService.FindByEmailAsync(email);
                    var roles = await this.identityService.GetRolesAsync(user);

                    if (roles.Contains(BASE_USER_ROLE))
                    {
                       return "Administrator Logged in";                      
                    }
                    else
                    {
                        throw new AdminRoleLoginException("User can't log in with administrative role.");
                    }                 
                }

                if (result.IsLockedOut)
                {
                    throw new UserAccountLockedOutException("User account locked out.");                   
                }
                else
                {
                    throw new InvalidLoginAtemptException("Invalid login attempt.");                  
                }
            
          
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        }

        public async Task<string> SignOutAsync()
        {
            try
            {
                await this.identityService.SignOutAsync();

                return "User logged out.";
            }
            catch (Exception ex)
            {

                throw new SignOutException($"Can't Sign out: {ex.Message}");
            }
           
        }

        public async Task<bool> ForgotPassword(string userEmail)
        {
            var user = await this.identityService.FindByEmailAsync(userEmail);
            if (user == null || !(await this.identityService.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                throw new ForgotenPasswordException("User does not exist or is not confirmed");
            }

            // For more information on how to enable account confirmation and password reset please
            // visit https://go.microsoft.com/fwlink/?LinkID=532713

            return true;
        }
    }
    
}
