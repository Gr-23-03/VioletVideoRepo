using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrdertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "OrderPrice" },
                values: new object[] { 1, 1, new DateTime(2023, 11, 29, 11, 8, 49, 927, DateTimeKind.Local).AddTicks(8261), 129m });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "Id", "MovieId", "OrderId", "Price" },
                values: new object[] { 1, 1, 1, 129m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
