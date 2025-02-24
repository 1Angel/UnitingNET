using Microsoft.AspNetCore.Identity;
using UnitingBE.Entities;

namespace UnitingBE.Database
{
    public static class SeedAdminUser
    {
        public static async Task SeedAmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            var admin_user = new AppUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var create = await userManager.CreateAsync(admin_user, "Admin01_");
            if (create.Succeeded)
            {
                if(await roleManager.RoleExistsAsync(UserRoles.Admin) && await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await userManager.AddToRoleAsync(admin_user, UserRoles.Admin);
                }
            }

        }
    }
}
