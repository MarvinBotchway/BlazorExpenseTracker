using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorExpenseTracker.Server.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CreatedAt" },
                values: new object[] { 1, 10.0m, new DateTime(2023, 1, 31, 6, 4, 30, 918, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CreatedAt" },
                values: new object[] { 2, 100.0m, new DateTime(2023, 1, 31, 7, 4, 30, 918, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CreatedAt" },
                values: new object[] { 3, 0.0m, new DateTime(2023, 1, 31, 8, 4, 30, 918, DateTimeKind.Utc).AddTicks(4201) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
