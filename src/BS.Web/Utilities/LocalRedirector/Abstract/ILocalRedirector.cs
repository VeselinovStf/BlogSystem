using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Web.Utilities.LocalRedirector.Abstract
{
    public interface ILocalRedirector
    {
        IActionResult RedirectToLocal(ControllerBase controllerBase, IUrlHelper helper, string returnUrl, string controllerName, string actionName, string area);
    }
}
