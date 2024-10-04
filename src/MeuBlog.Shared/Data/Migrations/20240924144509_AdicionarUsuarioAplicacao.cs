using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuBlog.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarUsuarioAplicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioAplicacaoId",
                table: "Autores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_UsuarioAplicacaoId",
                table: "Autores",
                column: "UsuarioAplicacaoId",
                unique: true,
                filter: "[UsuarioAplicacaoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_AspNetUsers_UsuarioAplicacaoId",
                table: "Autores",
                column: "UsuarioAplicacaoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_AspNetUsers_UsuarioAplicacaoId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_UsuarioAplicacaoId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "UsuarioAplicacaoId",
                table: "Autores");
        }
    }
}
