using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elhoot_HomeDevices.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatestoredate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "storeDates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "storeDates");
        }
    }
}
