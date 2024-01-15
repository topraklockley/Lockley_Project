using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FinalDay5Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 15, 21, 16, 34, 725, DateTimeKind.Local).AddTicks(3103));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 15, 21, 10, 47, 869, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");
        }
    }
}
