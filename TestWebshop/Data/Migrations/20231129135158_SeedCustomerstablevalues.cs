using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerstablevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "OrderPrice" },
                values: new object[] { 1, 1, new DateTime(2023, 11, 29, 14, 51, 58, 350, DateTimeKind.Local).AddTicks(1610), 129m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
