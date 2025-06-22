using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSetlistApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLienSongsterr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LienSongsterr",
                table: "Morceaux");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LienSongsterr",
                table: "Morceaux",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
