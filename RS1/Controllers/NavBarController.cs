using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RS1.DAL;
using RS1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RS1.Controllers
{
    public class NavBarController : Controller
    {
        // GET: NavBar
        public ActionResult GetNavRightSide()
        {
            Debug.WriteLine("Called Navbar controller !");
            AppUser user = UserManager.FindById(User.Identity.GetUserId());

            return PartialView(user);
        }

        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

    }
}