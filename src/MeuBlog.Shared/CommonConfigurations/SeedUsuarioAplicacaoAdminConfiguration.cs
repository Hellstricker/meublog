using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MeuBlog.Shared.CommonConfigurations
{
    public static class SeedUsuarioAplicacaoAdminConfiguration
    {
        public static void SeedUsuarioAplicacaoAdmin(this ModelBuilder modelBuilder, DbSet<IdentityUser> users, DbSet<Autor> autores )
        {
            var roleId = "6e8fc543-d816-4592-88de-43c1e1684c1a";
            var userId = "4936c34c-d5a9-4adf-81d5-2f6d956dbc32";

            var userEmail = "teste@teste.com";
            var userName = "Administrador";
            var userPassword = "Blog#1234";

            SeedRoles(modelBuilder, roleId);
            SeedUsuario(modelBuilder, userId,userEmail, userName, userPassword);
            SeedUserRole(modelBuilder, userId, roleId);
            SeedAutor(modelBuilder, userId, userName);

        }
        private static void SeedRoles(ModelBuilder modelBuilder, string roleId)
        {
            var role = new IdentityRole()
            {
                Id = roleId,
                Name = ERoles.Admin.ToString(),
                NormalizedName = ERoles.Admin.ToString().ToUpper()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);
        }
        private static void SeedUsuario(ModelBuilder modelBuilder, string userId, string userEmail, string userName, string userPassword)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var passwordHash = hasher.HashPassword(null, userPassword);
            var usuarioAplicacao = new IdentityUser ()
            {
                Id = userId,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = userEmail,
                NormalizedEmail = userEmail.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = passwordHash                
            };
            modelBuilder.Entity<IdentityUser>().HasData(usuarioAplicacao);
        }

        private static void SeedAutor(ModelBuilder modelBuilder, string userId, string userName)
        {
            var autor = new Autor()
            {
                Id = userId,
                Nome = userName                
            };
            modelBuilder.Entity<Autor>().HasData(autor);
        }

        private static void SeedUserRole(ModelBuilder modelBuilder, string userId, string roleId)
        {
            var identityRole = new IdentityUserRole<string>()
            {
                RoleId = roleId,
                UserId = userId
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityRole);
        }
    }


}
