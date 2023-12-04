using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateintoCustomerstablevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 14, 56, 57, 4, DateTimeKind.Local).AddTicks(2664));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 14, 52, 24, 659, DateTimeKind.Local).AddTicks(4736));
        }
    }
}
