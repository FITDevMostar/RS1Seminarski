using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RS1.Models;
using RS1.DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace RS1.Controllers
{

    [Authorize(Roles = "User, Administrator")]
    public class HomeController : Controller
    {   
        [AllowAnonymous] 
        public ActionResult Index()
        {

            AppUser user = UserManager.FindById(User.Identity.GetUserId());
            return View(user);   
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}