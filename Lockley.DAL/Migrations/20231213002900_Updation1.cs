using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 13, 3, 29, 0, 72, DateTimeKind.Local).AddTicks(4973));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 3, 3, 44, 54, 168, DateTimeKind.Local).AddTicks(524));
        }
    }
}
