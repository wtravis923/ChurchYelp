using System;
using System.Collections.Generic;
using System.Linq;
using ChurchYelp.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChurchYelp.WebApi.Startup))]

namespace ChurchYelp.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);

            ConfigureAuth(app);
            createRolesandUsers();
        }
        //create default User roles and Admin User for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //first Admin Role and default admin user
            if (!roleManager.RoleExists("Admin"))
            {
                //create admin rule 
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //create an Admin Super user who will maintain the website
                var user = new ApplicationUser();
                user.UserName = "Sarah";
                user.Email = "sarah.spriggs01@gmail.com";

                string userPWD = "Password123!";

                var chkUser = UserManager.Create(user, userPWD);

                //add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

        
        }
    }
}
