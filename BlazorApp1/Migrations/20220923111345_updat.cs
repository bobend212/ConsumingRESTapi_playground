using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    public partial class updat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_CharacterDb_CharacterId",
                table: "Notebooks");

            migrationBuilder.DropTable(
                name: "CharacterDb");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Notebooks",
                newName: "Characterid");

            migrationBuilder.RenameIndex(
                name: "IX_Notebooks_CharacterId",
                table: "Notebooks",
                newName: "IX_Notebooks_Characterid");

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    species = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_Result_Characterid",
                table: "Notebooks",
                column: "Characterid",
                principalTable: "Result",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_Result_Characterid",
                table: "Notebooks");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.RenameColumn(
                name: "Characterid",
                table: "Notebooks",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Notebooks_Characterid",
                table: "Notebooks",
                newName: "IX_Notebooks_CharacterId");

            migrationBuilder.CreateTable(
                name: "CharacterDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterDb", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_CharacterDb_CharacterId",
                table: "Notebooks",
                column: "CharacterId",
                principalTable: "CharacterDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
