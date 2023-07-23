using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace sattiAldi.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin role" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user role" };
                manager.Create(role);
            }

            if (!context.Users.Any(r => r.Name == "atakanturgut"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() 
                { 
                    Name = "Atakan", 
                    Surname = "Turgut",
                    Email = "atakan@turgut.com", 
                    UserName = "atakanturgut"
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(r => r.Name == "furkanuvenc"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser()
                {
                    Name = "Furkan",
                    Surname = "Üvenç",
                    Email = "furkan@uvenc.com",
                    UserName = "furkanuvenc"
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);
        }
    }
}