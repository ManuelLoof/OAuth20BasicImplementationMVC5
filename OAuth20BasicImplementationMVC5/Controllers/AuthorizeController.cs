using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth20BasicImplementationMVC5.Controllers
{
    [Authorize]
    public class AuthorizeController : Controller
    {
        // GET: HelloWorld
        [AllowAnonymous]
        public ActionResult Index()
        {
            // The Authorize attribute do not work. We get an infinity loop. 
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/HelloWorld" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }

            return View();
        }
    }
}