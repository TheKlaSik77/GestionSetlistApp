using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSetlistApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMembreEvenement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembreEvenement");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Album",
                table: "Morceaux",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MembreEvenement",
                columns: table => new
                {
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    EvenementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembreEvenement", x => new { x.MembreId, x.EvenementId });
                    table.ForeignKey(
                        name: "FK_MembreEvenement_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "EvenementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembreEvenement_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "MembreId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MembreEvenement_EvenementId",
                table: "MembreEvenement",
                column: "EvenementId");
        }
    }
}
