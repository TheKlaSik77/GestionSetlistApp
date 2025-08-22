﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSetlistApp.Migrations
{
    /// <inheritdoc />
    public partial class AjoutLienYoutubeDansMorceau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LienYoutube",
                table: "Morceaux",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LienYoutube",
                table: "Morceaux");
        }
    }
}
