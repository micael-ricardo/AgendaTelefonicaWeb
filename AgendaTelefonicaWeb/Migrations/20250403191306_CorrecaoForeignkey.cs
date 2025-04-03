﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaTelefonicaWeb.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoForeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Contato");
        }
    }
}
