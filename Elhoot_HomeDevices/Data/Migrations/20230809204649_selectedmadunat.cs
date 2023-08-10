using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elhoot_HomeDevices.Data.Migrations
{
    /// <inheritdoc />
    public partial class selectedmadunat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedDates_Orders_OrderId",
                table: "SelectedDates");

            migrationBuilder.DropIndex(
                name: "IX_SelectedDates_OrderId",
                table: "SelectedDates");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "SelectedDates",
                newName: "MadunatID");

            migrationBuilder.AddColumn<int>(
                name: "MadunaateId",
                table: "SelectedDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountMonth",
                table: "madunaates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDates_MadunaateId",
                table: "SelectedDates",
                column: "MadunaateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedDates_madunaates_MadunaateId",
                table: "SelectedDates",
                column: "MadunaateId",
                principalTable: "madunaates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedDates_madunaates_MadunaateId",
                table: "SelectedDates");

            migrationBuilder.DropIndex(
                name: "IX_SelectedDates_MadunaateId",
                table: "SelectedDates");

            migrationBuilder.DropColumn(
                name: "MadunaateId",
                table: "SelectedDates");

            migrationBuilder.DropColumn(
                name: "CountMonth",
                table: "madunaates");

            migrationBuilder.RenameColumn(
                name: "MadunatID",
                table: "SelectedDates",
                newName: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDates_OrderId",
                table: "SelectedDates",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedDates_Orders_OrderId",
                table: "SelectedDates",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
