using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elhoot_HomeDevices.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "Startdate");

            migrationBuilder.RenameColumn(
                name: "Custoname",
                table: "Orders",
                newName: "productNmae");

            migrationBuilder.AddColumn<decimal>(
                name: "AllPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Enddate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PayedPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Penfits",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Peroid",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceAfterBenfits",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RestPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Enddate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PayedPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Penfits",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Peroid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PriceAfterBenfits",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RestPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "productNmae",
                table: "Orders",
                newName: "Custoname");

            migrationBuilder.RenameColumn(
                name: "Startdate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
