using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSetlistApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifEvenementsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Setlists_SetlistId",
                table: "Evenements");

            migrationBuilder.AlterColumn<int>(
                name: "SetlistId",
                table: "Evenements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenements_Setlists_SetlistId",
                table: "Evenements",
                column: "SetlistId",
                principalTable: "Setlists",
                principalColumn: "SetlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Setlists_SetlistId",
                table: "Evenements");

            migrationBuilder.AlterColumn<int>(
                name: "SetlistId",
                table: "Evenements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evenements_Setlists_SetlistId",
                table: "Evenements",
                column: "SetlistId",
                principalTable: "Setlists",
                principalColumn: "SetlistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
