using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elhoot_HomeDevices.Data.Migrations
{
    /// <inheritdoc />
    public partial class cutomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequance",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequance",
                table: "Customers");
        }
    }
}
