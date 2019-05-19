using System;
using System.Threading.Tasks;

namespace BS.WEB.AccountControllerValidation.Abstract
{
    public interface IAccountControllerValidation
    {
       Task<string> Login(string email, string password, bool rememberMe);

        Task<string> SignOutAsync();

        Task<bool> ForgotPassword(string userEmail);
    }
}
