using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoSeed4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c7d78c04-9d24-4254-a8dd-da2e4719f9c8", "TESTE@TESTE.COM", null, "f37b6167-58dc-4142-be7a-948f6fb0226a", "teste@teste.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "97f664c8-7e13-41e2-95ac-c72e7329c4c2", "ADMINISTRADOR", "AQAAAAIAAYagAAAAEAW5RFQVTXU4vU0zGuiAVKIBDdxui5dL7IELSWtoYm/fQ//+xg0lZEPSpc7Q8SxreA==", "", "Administrador" });
        }
    }
}
