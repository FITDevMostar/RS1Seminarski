using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.DAL
{
    public class AppRoleManager : RoleManager<AppRole>
    {
        public AppRoleManager(RoleStore<AppRole> store) : base(store) { }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            EFDbContext db = context.Get<EFDbContext>();
            AppRoleManager manager = new AppRoleManager(new RoleStore<AppRole>(db));
            return manager; 
        }
    }
}