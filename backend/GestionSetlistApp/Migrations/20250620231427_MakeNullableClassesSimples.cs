using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSetlistApp.Migrations
{
    /// <inheritdoc />
    public partial class MakeNullableClassesSimples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LienYoutube",
                table: "Morceaux",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LienSongsterr",
                table: "Morceaux",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "DureeMorceau",
                table: "Morceaux",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Album",
                table: "Morceaux",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
                name: "DureeSetlist",
                table: "Setlists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Morceaux",
                keyColumn: "LienYoutube",
                keyValue: null,
                column: "LienYoutube",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LienYoutube",
                table: "Morceaux",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Morceaux",
                keyColumn: "LienSongsterr",
                keyValue: null,
                column: "LienSongsterr",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LienSongsterr",
                table: "Morceaux",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "DureeMorceau",
                table: "Morceaux",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Morceaux",
                keyColumn: "Album",
                keyValue: null,
                column: "Album",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Album",
                table: "Morceaux",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
