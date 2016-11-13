using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using RS1.DAL;

namespace RS1
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder builder)
        {
            // startup class for OWIN

            builder.CreatePerOwinContext<EFDbContext>(EFDbContext.Create);
            builder.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            builder.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            // creates cookie auth with where to send user if he's not auth.

            builder.UseCookieAuthentication(new CookieAuthenticationOptions {

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login") // ako user nije logiran , posalji ga na ovo.

            });
        }

    }
}