using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Notebooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_CharacterId",
                table: "Notebooks",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_CharacterDb_CharacterId",
                table: "Notebooks",
                column: "CharacterId",
                principalTable: "CharacterDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_CharacterDb_CharacterId",
                table: "Notebooks");

            migrationBuilder.DropTable(
                name: "CharacterDb");

            migrationBuilder.DropIndex(
                name: "IX_Notebooks_CharacterId",
                table: "Notebooks");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Notebooks");
        }
    }
}
