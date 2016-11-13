using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using RS1.ViewModel;
using RS1.Models;
using RS1.DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Diagnostics;
using System.Text;

namespace RS1.Controllers
{
    [Authorize (Roles = "User,Administrator")]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Username, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "User");

                    /*
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = new Uri(Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }
                    , protocol: Request.Url.Scheme));
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Hello "+user.UserName+", please confirm your account by clicking <a href = "+callbackUrl+"> Here </a>");
                    */

                    return RedirectToAction("Profile", "Account");
                }   
            }

            return View(model);

        }

        [AllowAnonymous]
        public ActionResult EmailConfirmMessage()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
            
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(model.Username, model.Password);

                if(user == null)
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }else
                {
                   ClaimsIdentity identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect("/Home/Index");
                    }

                    return Redirect(returnUrl);
                }

            }

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Profile()
        {

            AppUser user = UserManager.FindById(User.Identity.GetUserId());
            return View(user);

        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            StringBuilder builder = new StringBuilder(code);
            builder.Replace(" ", "+");
            string real_code = builder.ToString();

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(real_code))
            {
                Debug.WriteLine("condition not met!");
                return RedirectToAction("Index", "Home");
            }

            IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                UserManager.AddToRole(userId, "User");
                return RedirectToAction("Profile", "Account");
            }else
            {
                Debug.WriteLine("result not suceeded");
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            AppUser user = UserManager.FindById(User.Identity.GetUserId());
            ChangePasswordModel model = new ChangePasswordModel();

            if(user == null)
            {
                model.isLoged = false;
            }else
            {
                model.isLoged = true;
                model.Username = user.UserName;
            }

            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model, string Username)
        {

            string username = Username;
            if (string.IsNullOrEmpty(username))
            {
                username = model.Username;
            }

            AppUser user = UserManager.FindByName(username);
            IdentityResult result = await UserManager.ChangePasswordAsync(user.Id, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                AuthManager.SignOut();
                return RedirectToAction("Index", "Home");
            }else
            {
                return View(model);
            }
        }


       private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        private AppRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); }
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