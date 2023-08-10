﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elhoot_HomeDevices.Data.Migrations
{
    /// <inheritdoc />
    public partial class stordate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Statuse",
                table: "storeDates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statuse",
                table: "storeDates");
        }
    }
}
