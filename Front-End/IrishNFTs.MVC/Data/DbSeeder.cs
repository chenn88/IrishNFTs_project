using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IrishNFTs.MVC.Constants;

namespace IrishNFTs.MVC.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            var user = new IdentityUser
            {
                UserName = "admin@irishnfts.com",
                Email = "admin@irishnfts.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin2023!");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());

            }
        }

    }
}