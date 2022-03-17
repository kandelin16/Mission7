using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public static class IdentitySeedData
    {
        private const string AdminUser = "Admin";
        private const string Password = "413ExtraYeetPeriod(t)!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDBContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppIdentityDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(AdminUser);

            if (user == null)
            {
                user = new IdentityUser(AdminUser);

                user.Email = "admin@mission7.com";
                user.PhoneNumber = "7755555555";
                await userManager.CreateAsync(user, Password);
            }
        }
    }
}
