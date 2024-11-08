using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6182acd-7380-4217-93ec-994d34baa64f", "AQAAAAIAAYagAAAAECgczd8Xt/klW/mDUmwaySbbMPQCQ7uoztHSEat6f2xuqCcO/zH9AGDGhPtB8WBxEw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4936c34c-d5a9-4adf-81d5-2f6d956dbc32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91a9d2e1-4522-453b-97f8-d24e60c8ee18", "AQAAAAIAAYagAAAAEGIMwe3cBLD5n5M1S+WiqrOFkjlrSynzJ2MmRYk/zZwg+sw7dtLWivNRer9wL6ByeQ==" });
        }
    }
}
