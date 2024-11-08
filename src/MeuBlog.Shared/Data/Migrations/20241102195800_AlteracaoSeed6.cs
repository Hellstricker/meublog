using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoSeed6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "58aaf969-e4ef-45d0-af3c-bafdf07fd540", "TESTE@TESTE.COM", "AQAAAAIAAYagAAAAEP+hZ/s3GlJmSh9Umslpz/DZlidRXTEBoRT6h9NX8WkXHBrYdViAzTDQ0+fnhm5TnA==", "26b87e37-ebb0-4b45-9fa8-eb80bda5f72a", "teste@teste.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "292df08a-a464-4d0a-aa95-fc183de4b9ff", "ADMINISTRADOR", "AQAAAAIAAYagAAAAENwDwonZhlA1CaW0cE+J0kTc4s6dkbiuzWHtdKGL4CILZa3RUM7qp2peEwi+aC+lhw==", "1e68baa7-2678-4415-8f05-482a24ea39eb", "Administrador" });
        }
    }
}
