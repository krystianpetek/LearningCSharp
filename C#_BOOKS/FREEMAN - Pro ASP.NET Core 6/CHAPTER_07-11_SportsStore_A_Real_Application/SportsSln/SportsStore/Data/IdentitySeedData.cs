using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data.DbContexts;

namespace SportsStore.Data
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        private const string adminEmail = "admin@example.com";
        private const string adminPhone = "555-1234";

        public static async Task EnsurePopulated(this IApplicationBuilder app) {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            if(context.Database.IsRelational() && context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser? user = await userManager.FindByNameAsync(adminUser);
            if(user == default)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = adminEmail,
                    PhoneNumber = adminPhone
                };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
