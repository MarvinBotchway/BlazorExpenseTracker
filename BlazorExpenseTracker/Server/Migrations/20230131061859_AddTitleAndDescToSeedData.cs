using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorExpenseTracker.Server.Migrations
{
    public partial class AddTitleAndDescToSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 31, 6, 18, 58, 919, DateTimeKind.Utc).AddTicks(6702), "Bought a Snack" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 31, 7, 18, 58, 919, DateTimeKind.Utc).AddTicks(6706), "Bought a phone" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 31, 8, 18, 58, 919, DateTimeKind.Utc).AddTicks(6713), "Bought Lunch" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 31, 6, 13, 14, 928, DateTimeKind.Utc).AddTicks(9955), "" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 31, 7, 13, 14, 928, DateTimeKind.Utc).AddTicks(9959), "" });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Title" },
                values: new object[] { new DateTime(2023, 1, 31, 8, 13, 14, 928, DateTimeKind.Utc).AddTicks(9969), "" });
        }
    }
}
