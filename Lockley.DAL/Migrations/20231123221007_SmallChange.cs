using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SmallChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 11, 24, 1, 10, 7, 268, DateTimeKind.Local).AddTicks(6021));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 11, 18, 5, 9, 34, 888, DateTimeKind.Local).AddTicks(5329));
        }
    }
}
