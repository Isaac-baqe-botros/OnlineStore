using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elhoot_HomeDevices.Data.Migrations
{
    /// <inheritdoc />
    public partial class datefree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFree",
                table: "storeDates",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFree",
                table: "storeDates");
        }
    }
}
