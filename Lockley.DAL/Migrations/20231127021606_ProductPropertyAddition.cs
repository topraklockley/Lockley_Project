using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductPropertyAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CargoDetail",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 11, 27, 5, 16, 6, 340, DateTimeKind.Local).AddTicks(7752));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoDetail",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 11, 27, 0, 43, 32, 986, DateTimeKind.Local).AddTicks(7199));
        }
    }
}
