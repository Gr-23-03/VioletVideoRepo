using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerstablevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "OrderPrice" },
                values: new object[] { 1, 1, new DateTime(2023, 11, 29, 14, 29, 38, 462, DateTimeKind.Local).AddTicks(5581), 129m });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "Id", "MovieId", "OrderId", "Price" },
                values: new object[] { 1, 1, 1, 129m });
        }
    }
}
