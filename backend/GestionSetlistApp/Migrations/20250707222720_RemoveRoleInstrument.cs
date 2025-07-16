using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSetlistApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleInstrument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Setlists_SetlistId",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Instruments");

            migrationBuilder.AlterColumn<int>(
                name: "DureeSetlist",
                table: "Setlists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Setlists_SetlistId",
                table: "Evenements");

            migrationBuilder.AlterColumn<int>(
                name: "DureeSetlist",
                table: "Setlists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Instruments",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
