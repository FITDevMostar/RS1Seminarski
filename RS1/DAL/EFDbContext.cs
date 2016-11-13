using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RS1.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace RS1.DAL
{
    public class EFDbContext : IdentityDbContext<AppUser>
    {
        public EFDbContext() : base("EFDbContext") { }

        static EFDbContext() { Database.SetInitializer<EFDbContext>(new InitDb()); }

        public static EFDbContext Create()
        {
            return new EFDbContext();
        }

    }

    public class InitDb : DropCreateDatabaseIfModelChanges<EFDbContext>
    {

        protected override void Seed(EFDbContext context)
        {
            PerformInitSetup(context);
            base.Seed(context);
        }

        public void PerformInitSetup(EFDbContext context)
        {
            // init config goes here ..

            AppUserManager UserManager = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager RoleManager = new AppRoleManager(new RoleStore<AppRole>(context));

            string admin_role_name = "Administrator";
            string instructor_role_name = "Instructor";
            string user_role_name = "User";

            string admin_username = "root";
            string admin_pass = "rootpass";

            RoleManager.Create(new AppRole(user_role_name));
            RoleManager.Create(new AppRole(instructor_role_name));

            // napravi admin role-u

            if (!RoleManager.RoleExists(admin_role_name))
            {
                AppRole role = new AppRole(admin_role_name);
                RoleManager.Create(role);
            }

            // napravi admin user-a
            AppUser user = UserManager.FindByName(admin_username);
            if(user == null)
            {
                UserManager.Create(new AppUser { UserName = admin_username }, admin_pass);
                user = UserManager.FindByName(admin_username);
            }

            // dodaj admin user-a u admin role-u

            if (!UserManager.IsInRole(user.Id, admin_role_name))
            {
                UserManager.AddToRole(user.Id, admin_role_name);
            }

            // napravi user role-u

        }
    }

}