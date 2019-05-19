using BS.Identity.Service.BaseIdentityUserService.Abstract;
using BS.Web.Utilities.LocalRedirector.Abstract;
using BS.WEB.AccountControllerValidation.Abstract;
using BS.WEB.ControllerValidation.Exceptions;
using BS.WEB.ViewModels.Identity;
using BS.WEB.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountControllerValidation _accountControllerValidation;
        private readonly ILogger<AccountController> _logger;
        private readonly ILocalRedirector _localRedirector;
        public const string BASE_USER_ROLE = "Administrator";

        public AccountController(
            IAccountControllerValidation accountControllerValidation, 
            ILogger<AccountController> logger,
            ILocalRedirector localRedirector)
        {
            this._accountControllerValidation = accountControllerValidation;
            this._logger = logger;
            this._localRedirector = localRedirector;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            try
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
             
                _logger.LogInformation("Sign out for login done");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                throw new ArgumentException(ex.Message);
            }

            LoginViewModel model = new LoginViewModel()
            {
                BackgroundImage = "",
                PageTitle = "Admin Login",
                HeaderTitle = "Admin Login"
            };
          
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;

                try
                {
                    var controllerValidatorCall = await this._accountControllerValidation.Login(model.Email, model.Password, model.RememberMe);

                    this._logger.LogInformation(controllerValidatorCall);

                    return RedirectToLocal("Index", "Home");
                }              
                catch (Exception ex)
                {
                    this._logger.LogError(ex.Message);

                    model.ErrorMessage = ex.Message;

                    return View(model);
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
              
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            try
            {
                var controllerValidatorCall = await this._accountControllerValidation.SignOutAsync();

                this._logger.LogInformation(controllerValidatorCall);

                if (returnUrl != null)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    PageHeaderViewModel model = new PageHeaderViewModel()
                    {
                        BackgroundImage = "",
                        PageTitle = "LogOut",
                        HeaderTitle = "LogOut"
                    };

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                throw new ArgumentException(ex.Message);
            }

        }

        public IActionResult AccessDenied()
        {
            PageHeaderViewModel model = new PageHeaderViewModel()
            {
                BackgroundImage = "",
                PageTitle = "Access Denied",
                HeaderTitle = "Access is Denied"
            };

            return View(model);
        }

      



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            LoginViewModel model = new LoginViewModel()
            {
                BackgroundImage = "",
                PageTitle = "Lockout",
                HeaderTitle = "You account is Lockout"
            };

            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl, string controller = "Home", string action = "Index", string area = "")
        {
            return this._localRedirector.RedirectToLocal(this, Url, returnUrl, controller, action, area);
        }
    }
}
