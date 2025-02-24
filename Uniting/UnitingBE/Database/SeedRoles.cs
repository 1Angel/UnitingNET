using Microsoft.AspNetCore.Identity;
using UnitingBE.Entities;

namespace UnitingBE.Database
{
    public static class SeedRoles
    {
        public static async Task SeedRole(IServiceProvider serviceProvider)
        {
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin) && (!await _roleManager.RoleExistsAsync(UserRoles.User)))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            };
        }
    }
}
