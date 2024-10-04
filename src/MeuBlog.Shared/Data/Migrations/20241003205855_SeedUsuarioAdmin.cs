using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuarioAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "535e42c6-355d-4d18-b146-6ac6463fa318", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7bfdaa3c-5099-4da5-882e-58d59e9f4e72", 0, "65a84287-c243-41e2-a84b-0c9a32b08bf7", "teste@teste.com", true, false, null, "TESTE@TESTE.COM", "ADMINISTRADOR", "AQAAAAIAAYagAAAAEN4m+Of7ZrA8vIK14cZ8a8qeQpVrDfMBzUgndsYdSzXLrKcJ4CYNQDf/I19kiSAbCQ==", null, false, "", false, "Administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "535e42c6-355d-4d18-b146-6ac6463fa318", "7bfdaa3c-5099-4da5-882e-58d59e9f4e72" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nome", "UsuarioAplicacaoId" },
                values: new object[] { 1, "Administrador", "7bfdaa3c-5099-4da5-882e-58d59e9f4e72" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "535e42c6-355d-4d18-b146-6ac6463fa318", "7bfdaa3c-5099-4da5-882e-58d59e9f4e72" });

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "535e42c6-355d-4d18-b146-6ac6463fa318");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bfdaa3c-5099-4da5-882e-58d59e9f4e72");
        }
    }
}
