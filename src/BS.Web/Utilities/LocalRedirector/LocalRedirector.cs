using BS.Web.Utilities.LocalRedirector.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.Utilities.LocalRedirector
{
    public class LocalRedirector : ILocalRedirector
    {
        public IActionResult RedirectToLocal(ControllerBase controllerBase, IUrlHelper helper, string returnUrl, string controllerName, string actionName, string areaName)
        {
            if (helper.IsLocalUrl(returnUrl))
            {
                return controllerBase.Redirect(returnUrl);
            }
            else
            {
                return controllerBase.RedirectToAction(actionName, controllerName);
            }
        }
    }
}
