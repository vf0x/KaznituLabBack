using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EFData.Seed
{
    public static class KaznituLabInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@example.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@example.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Zz1234567!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
