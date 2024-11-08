using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class MusancaSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e8fc543-d816-4592-88de-43c1e1684c1a", "4936c34c-d5a9-4adf-81d5-2f6d956dbc32" });

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8fc543-d816-4592-88de-43c1e1684c1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e8fc543-d816-4592-88de-43c1e1684c1a", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4936c34c-d5a9-4adf-81d5-2f6d956dbc32", 0, "8c6fa2ea-aaf6-402d-a6ab-f5461ccf016a", "teste@teste.com", true, false, null, "TESTE@TESTE.COM", "ADMINISTRADOR", "AQAAAAIAAYagAAAAEMWkcwawGmYKcNv5etJyXxtPQciFIX7u3ZHnbMsTK+0Bx+AiCCRnpKqXv5Bey9pe3w==", null, false, "", false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "4936c34c-d5a9-4adf-81d5-2f6d956dbc32", "Administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6e8fc543-d816-4592-88de-43c1e1684c1a", "4936c34c-d5a9-4adf-81d5-2f6d956dbc32" });
        }
    }
}
