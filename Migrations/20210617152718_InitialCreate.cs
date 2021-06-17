using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetAspExample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: true),
                    fechaLanzamiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Artistaid = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Discos_Artistas_Artistaid",
                        column: x => x.Artistaid,
                        principalTable: "Artistas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discos_Artistaid",
                table: "Discos",
                column: "Artistaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discos");

            migrationBuilder.DropTable(
                name: "Artistas");
        }
    }
}
