using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndOrderDetailAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPicture_Product_ProductID",
                table: "ProductPicture");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductPicture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    PaymentOption = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    EMailAddress = table.Column<string>(type: "Varchar(80)", maxLength: 80, nullable: true),
                    ShippingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    ProductPicture = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 12, 3, 2, 50, 6, 917, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPicture_Product_ProductID",
                table: "ProductPicture",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPicture_Product_ProductID",
                table: "ProductPicture");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductPicture",
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
                value: new DateTime(2023, 11, 28, 15, 21, 48, 64, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPicture_Product_ProductID",
                table: "ProductPicture",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
