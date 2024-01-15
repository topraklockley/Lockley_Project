using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lockley.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "Varchar(33)", maxLength: 33, nullable: false),
                    FullName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slogan = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    FilePath = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Link = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "FullName", "LastLoginDate", "LastLoginIP", "Password", "Username" },
                values: new object[] { 1, "Toprak Lockley", new DateTime(2023, 11, 18, 5, 9, 34, 888, DateTimeKind.Local).AddTicks(5329), "", "e72056c6aa6c53dcf7806d37120ecb07", "toprak" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Slide");
        }
    }
}
