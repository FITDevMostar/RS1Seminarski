using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RS1.Models;
using RS1.Services;

namespace RS1.DAL
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store) { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            EFDbContext db = context.Get<EFDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));

           // manager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if(dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    TokenLifespan = TimeSpan.FromHours(6)
                };
            }

            return manager;
        }
    }
}