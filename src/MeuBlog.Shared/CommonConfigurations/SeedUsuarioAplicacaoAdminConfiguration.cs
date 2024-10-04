using MeuBlog.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeuBlog.Shared.CommonConfigurations
{
    public static class SeedUsuarioAplicacaoAdminConfiguration
    {
        public static void SeedUsuarioAplicacaoAdmin(this ModelBuilder modelBuilder)
        {
            var roleId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            SeedRoles(modelBuilder, roleId);
            SeedUsuarioAplicacao(modelBuilder, userId);
            SeedUserRole(modelBuilder, userId, roleId);
            SeedAutor(modelBuilder, userId);

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
        private static void SeedUsuarioAplicacao(ModelBuilder modelBuilder, string userId)
        {
            var hasher = new PasswordHasher<UsuarioAplicacao>();
            var passwordHash = hasher.HashPassword(null, "Blog#1234");
            var usuarioAplicacao = new UsuarioAplicacao ()
            {
                Id = userId,
                UserName = "Administrador",
                NormalizedUserName = "ADMINISTRADOR",
                Email = "teste@teste.com",
                NormalizedEmail = "TESTE@TESTE.COM",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                SecurityStamp = string.Empty
            };
            modelBuilder.Entity<UsuarioAplicacao>().HasData(usuarioAplicacao);
        }

        private static void SeedAutor(ModelBuilder modelBuilder, string userId)
        {
            var autor = new Autor()
            {
                Id = 1,
                Nome = "Administrador",
                UsuarioAplicacaoId = userId
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
