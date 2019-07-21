using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.MvcWebUI.Entity;

namespace Project.MvcWebUI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roles
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() {Name = "admin", Description = "admin role"};
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user role" };
                manager.Create(role);
            }


            //Users

            if (!context.Users.Any(i => i.Name == "SeckinSerdem"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                    {Name = "Seckin", Surname = "Akca", UserName = "SeckinSerdem", Email = "akcasecking@gmail.com",};


                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "MelihKilicer"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                    { Name = "Melih", Surname = "Kilicer", UserName = "MelihKilicer", Email = "melihkilicer@gmail.com", };


                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}