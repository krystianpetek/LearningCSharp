using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Models;

public static class IdentitySeedData
{
    public static async Task SeedIdentityDatabase(this WebApplication app)
    {
        IServiceProvider serviceProvider = app.Services.CreateScope().ServiceProvider;
        UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string username = "admin";
        string email = "admin@example.com";
        string password = "Secret123$";
        string role = "Admins";

        if (await userManager.FindByNameAsync(username) == null)
        {
            if (await roleManager.FindByNameAsync(role) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
            IdentityUser user = new IdentityUser
            {
                UserName = username,
                Email = email
            };
            IdentityResult result = await userManager
            .CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
