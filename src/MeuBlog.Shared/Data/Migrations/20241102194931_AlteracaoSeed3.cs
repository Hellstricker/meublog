using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoSeed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97f664c8-7e13-41e2-95ac-c72e7329c4c2", "AQAAAAIAAYagAAAAEAW5RFQVTXU4vU0zGuiAVKIBDdxui5dL7IELSWtoYm/fQ//+xg0lZEPSpc7Q8SxreA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6182acd-7380-4217-93ec-994d34baa64f", "AQAAAAIAAYagAAAAECgczd8Xt/klW/mDUmwaySbbMPQCQ7uoztHSEat6f2xuqCcO/zH9AGDGhPtB8WBxEw==" });
        }
    }
}
