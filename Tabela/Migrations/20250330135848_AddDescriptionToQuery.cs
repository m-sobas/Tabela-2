﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabela.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToQuery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Queries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Queries");
        }
    }
}
