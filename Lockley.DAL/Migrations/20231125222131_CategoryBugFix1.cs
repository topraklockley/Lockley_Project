using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoryBugFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 11, 26, 1, 21, 31, 59, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentID",
                table: "Category",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentID",
                table: "Category",
                column: "ParentID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentID",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentID",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 11, 24, 7, 27, 6, 294, DateTimeKind.Local).AddTicks(6025));
        }
    }
}
