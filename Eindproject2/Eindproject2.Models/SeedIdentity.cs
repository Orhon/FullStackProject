using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject2.Models
{
    public class SeedIdentity
    {
        private readonly UserManager<Users> userMgr;
        private readonly RoleManager<IdentityRole> roleMgr;

        public SeedIdentity(UserManager<Users> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            this.userMgr = userMgr;
            this.roleMgr = roleMgr;
        }

        public async Task SeedIdentityEindproject2API()
        {
            var user = await userMgr.FindByNameAsync("ThibaultMarkey");

            // Add User
            if (user == null)
            {
                if (!(await roleMgr.RoleExistsAsync("Admin")))
                {
                    var role = new IdentityRole("Admin");
                    await roleMgr.CreateAsync(role);
                }

                user = new Users()
                {
                    UserName = "ThibaultMarkey",
                    FirstName = "Thibault",
                    LastName = "Markey",
                    Email = "thibault.markey@student.howest.be"
                };

                var userResult = await userMgr.CreateAsync(user, "ThibaultP@ssw0rd");
                var roleResult = await userMgr.AddToRoleAsync(user, "Admin");

                if (!userResult.Succeeded || !roleResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
        }
    }
}
