using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FinalDayMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 15, 20, 19, 41, 752, DateTimeKind.Local).AddTicks(540));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "OrderDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 15, 19, 49, 29, 74, DateTimeKind.Local).AddTicks(3207));
        }
    }
}
