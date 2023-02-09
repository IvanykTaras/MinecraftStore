using Microsoft.AspNetCore.Identity;

namespace MinecraftStore.Data
{
    public static class IdentitySeedData
    {
        private static string[] roles = new string[]{ "Admin", "User" };
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>));
                var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));
                


                foreach (string role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = role });
                }


                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                
                if (user == null)
                {
                    user = new IdentityUser(adminUser);
                    await userManager.CreateAsync(user, adminPassword);
                    await userManager.AddToRoleAsync(user, "Admin");
                }

                

                
            }
        }
    }
}
