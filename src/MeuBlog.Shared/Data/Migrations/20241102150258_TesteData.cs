using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class TesteData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "336dd8e0-25bb-4525-9b82-95aeddda9023", "71fcdd9d-98fa-4514-a3a5-d3438d3a7f41" });

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: "71fcdd9d-98fa-4514-a3a5-d3438d3a7f41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336dd8e0-25bb-4525-9b82-95aeddda9023");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71fcdd9d-98fa-4514-a3a5-d3438d3a7f41");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPublicacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f78f8562-ac56-4e35-9af5-1e5d6e452e90", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46bc95fd-ca84-49c9-a52f-aa3e6637aafb", 0, "09ee7bb9-a711-492d-b1f7-a9aa9a6f5620", "teste@teste.com", true, false, null, "TESTE@TESTE.COM", "ADMINISTRADOR", "AQAAAAIAAYagAAAAEFQtBks9XTS4hDyT2iZRoa97tKRevkEw9nuytU/OTBhZU1KO+ptaYOZpidYQmAHX1A==", null, false, "", false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "46bc95fd-ca84-49c9-a52f-aa3e6637aafb", "Administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f78f8562-ac56-4e35-9af5-1e5d6e452e90", "46bc95fd-ca84-49c9-a52f-aa3e6637aafb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f78f8562-ac56-4e35-9af5-1e5d6e452e90", "46bc95fd-ca84-49c9-a52f-aa3e6637aafb" });

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: "46bc95fd-ca84-49c9-a52f-aa3e6637aafb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f78f8562-ac56-4e35-9af5-1e5d6e452e90");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46bc95fd-ca84-49c9-a52f-aa3e6637aafb");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPublicacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "336dd8e0-25bb-4525-9b82-95aeddda9023", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71fcdd9d-98fa-4514-a3a5-d3438d3a7f41", 0, "b12781a2-dac0-447f-9253-0a4696d9b0fb", "teste@teste.com", true, false, null, "TESTE@TESTE.COM", "ADMINISTRADOR", "AQAAAAIAAYagAAAAEJbH7RhF8PHmf8/a65rYTirposvvFLS1bER6QfYKhBMe0oHzqrCW2MmEZbKN4SvUcA==", null, false, "", false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "71fcdd9d-98fa-4514-a3a5-d3438d3a7f41", "Administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "336dd8e0-25bb-4525-9b82-95aeddda9023", "71fcdd9d-98fa-4514-a3a5-d3438d3a7f41" });
        }
    }
}
