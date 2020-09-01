using BusinessTrack.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BusinessTrack.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            var memberRole = await roleManager.FindByNameAsync("Member");
            var adminUser = await roleManager.FindByNameAsync("Cihat");

            if (adminRole == null)
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });

            if (memberRole == null)
                await roleManager.CreateAsync(new AppRole { Name = "Member" });

            if (adminUser == null)
            {
                var appUser = new AppUser();
                appUser.Name = "Cihat";
                appUser.Surname = "SOLAK";
                appUser.UserName = "cihat.solak";
                appUser.Email = "cihat.solak@hotmail.com";

                var result = await userManager.CreateAsync(appUser, "1");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "Admin");
                }
            }
        }
    }
}
