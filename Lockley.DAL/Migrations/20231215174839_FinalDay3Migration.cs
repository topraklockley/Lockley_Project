using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FinalDay3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 15, 20, 48, 39, 763, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 15, 20, 19, 41, 752, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
