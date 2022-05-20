using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test4.Opzionale.RepositoryEF.Migrations
{
    public partial class Primo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSpesa = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Utente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Importo = table.Column<decimal>(type: "decimal", maxLength: 100, nullable: false),
                    Approvato = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spese_Categorie_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spese_CategoriaId",
                table: "Spese",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spese");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
