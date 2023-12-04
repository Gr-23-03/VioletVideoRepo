using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Customerstablevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 16, 9, 36, 736, DateTimeKind.Local).AddTicks(8808));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 15, 59, 13, 903, DateTimeKind.Local).AddTicks(4128));
        }
    }
}
