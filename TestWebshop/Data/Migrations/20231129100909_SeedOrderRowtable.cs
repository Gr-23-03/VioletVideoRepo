using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderRowtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 11, 9, 9, 358, DateTimeKind.Local).AddTicks(798));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 11, 8, 49, 927, DateTimeKind.Local).AddTicks(8261));
        }
    }
}
