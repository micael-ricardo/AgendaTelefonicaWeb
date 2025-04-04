using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaTelefonicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class AjusteFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contato_IdContato",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Contato");

            migrationBuilder.RenameColumn(
                name: "IdContato",
                table: "Telefone",
                newName: "ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_IdContato",
                table: "Telefone",
                newName: "IX_Telefone_ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_ContatoId",
                table: "Telefone",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contato_ContatoId",
                table: "Telefone");

            migrationBuilder.RenameColumn(
                name: "ContatoId",
                table: "Telefone",
                newName: "IdContato");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_ContatoId",
                table: "Telefone",
                newName: "IX_Telefone_IdContato");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_IdContato",
                table: "Telefone",
                column: "IdContato",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
