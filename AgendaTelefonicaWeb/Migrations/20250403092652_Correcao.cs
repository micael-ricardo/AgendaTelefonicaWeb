using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaTelefonicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contato_IDCONTATO",
                table: "Telefone");

            migrationBuilder.RenameColumn(
                name: "IDCONTATO",
                table: "Telefone",
                newName: "IdContato");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Telefone",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_IDCONTATO",
                table: "Telefone",
                newName: "IX_Telefone_IdContato");

            migrationBuilder.RenameColumn(
                name: "IDADE",
                table: "Contato",
                newName: "Idade");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Contato",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Telefone",
                type: "int",
                maxLength: 16,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_IdContato",
                table: "Telefone",
                column: "IdContato",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Contato_IdContato",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Telefone");

            migrationBuilder.RenameColumn(
                name: "IdContato",
                table: "Telefone",
                newName: "IDCONTATO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Telefone",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_IdContato",
                table: "Telefone",
                newName: "IX_Telefone_IDCONTATO");

            migrationBuilder.RenameColumn(
                name: "Idade",
                table: "Contato",
                newName: "IDADE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contato",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Contato_IDCONTATO",
                table: "Telefone",
                column: "IDCONTATO",
                principalTable: "Contato",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
