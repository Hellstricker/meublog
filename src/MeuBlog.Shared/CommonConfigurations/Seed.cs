using MeuBlog.Shared.Data;
using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeuBlog.Shared.CommonConfigurations
{
    public static class Seed
    {
        public static async Task SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await context.Database.MigrateAsync();

                var roleId = "6e8fc543-d816-4592-88de-43c1e1684c1a";
                var userId = "4936c34c-d5a9-4adf-81d5-2f6d956dbc32";

                var userEmail = "teste@teste.com";
                var userName = "Administrador";
                var userPassword = "Blog#1234";

                if (!await roleManager.RoleExistsAsync(ERoles.Admin.ToString()))
                {
                    var role = new IdentityRole()
                    {
                        Id = roleId,
                        Name = ERoles.Admin.ToString(),
                        NormalizedName = ERoles.Admin.ToString().ToUpper()
                    };
                    await roleManager.CreateAsync(role);
                }
                if (!await roleManager.RoleExistsAsync(ERoles.User.ToString()))
                {
                    var role = new IdentityRole()
                    {
                        Id = roleId,
                        Name = ERoles.User.ToString(),
                        NormalizedName = ERoles.User.ToString().ToUpper()
                    };
                    await roleManager.CreateAsync(role);
                }

                var adminUser = await userManager.FindByEmailAsync(userEmail);

                if (adminUser == null)
                {
                    adminUser = new IdentityUser()
                    {
                        Id = userId,
                        UserName = userName,
                        NormalizedUserName = userName.ToUpper(),
                        Email = userEmail,
                        NormalizedEmail = userEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = string.Empty
                    };

                    var result = await userManager.CreateAsync(adminUser, userPassword);

                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(adminUser, ERoles.Admin.ToString());
                }

                var authorExists = await context.Autores.AnyAsync(a => a.Id == adminUser.Id);

                if (!authorExists)
                {
                    var autor = new Autor()
                    {
                        Id = userId,
                        Nome = userName
                    };
                    context.Autores.Add(autor);
                    await context.SaveChangesAsync();
                }

            }

        }
    }
}
