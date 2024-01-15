using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductOrderDetailConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductPicture",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
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
                value: new DateTime(2023, 12, 3, 3, 44, 54, 168, DateTimeKind.Local).AddTicks(524));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductID",
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

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderDetail",
                type: "Varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductPicture",
                table: "OrderDetail",
                type: "Varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "OrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 3, 2, 50, 6, 917, DateTimeKind.Local).AddTicks(7670));
        }
    }
}
