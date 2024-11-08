using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "datetime('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "date('now')");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6a54a17-da55-439a-9b48-e7bab67301cf", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea4e102d-9e79-4197-b954-af3d95b7eb19", 0, "03f01b05-f068-4bdf-8cea-0eb6a6728ebe", "teste@teste.com", true, false, null, "TESTE@TESTE.COM", "ADMINISTRADOR", "AQAAAAIAAYagAAAAEJus0JRWdK8onqphUJCZINlIVfBbX4013RKxO5eMH7C/jOqW8cEZ1+VldnGoORbrug==", null, false, "", false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "ea4e102d-9e79-4197-b954-af3d95b7eb19", "Administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c6a54a17-da55-439a-9b48-e7bab67301cf", "ea4e102d-9e79-4197-b954-af3d95b7eb19" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6a54a17-da55-439a-9b48-e7bab67301cf", "ea4e102d-9e79-4197-b954-af3d95b7eb19" });

            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "Id",
                keyValue: "ea4e102d-9e79-4197-b954-af3d95b7eb19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6a54a17-da55-439a-9b48-e7bab67301cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea4e102d-9e79-4197-b954-af3d95b7eb19");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPublicacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "datetime('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Posts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "datetime('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "datetime('now')");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Comentarios",
                type: "datetime",
                nullable: false,
                defaultValueSql: "date('now')",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "datetime('now')");

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
    }
}
