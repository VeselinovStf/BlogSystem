using BS.Identity.Service.BaseIdentityUserService.Abstract;
using BS.Web.Utilities.LocalRedirector.Abstract;
using BS.WEB.AccountControllerValidation.Abstract;
using BS.WEB.ViewModels.Identity;
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

          
            ViewData["ReturnUrl"] = returnUrl;
            return View();
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

                    throw new ArgumentException(ex.Message);
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
                    return View();
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
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ExternalLogin()
        {
            return RedirectToLocal("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(await this._accountControllerValidation.ForgotPassword(model.Email))
                    {
                        this._logger.LogInformation("User valid - Confirm Forgotted Password");

                        return RedirectToAction(nameof(ForgotPasswordConfirmation));
                    }
                    else
                    {
                        this._logger.LogError("Can't find user for forgoten password confirmation");

                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.Message);

                    throw new ArgumentException("Can't change forgoten password");
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl, string controller = "Home", string action = "Index", string area = "")
        {
            return this._localRedirector.RedirectToLocal(this, Url, returnUrl, controller, action, area);
        }
    }
}
