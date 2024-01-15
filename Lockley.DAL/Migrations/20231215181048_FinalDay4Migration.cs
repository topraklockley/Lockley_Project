using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FinalDay4Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail");

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
                value: new DateTime(2023, 12, 15, 21, 10, 47, 869, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail");

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
                value: new DateTime(2023, 12, 15, 20, 48, 39, 763, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
