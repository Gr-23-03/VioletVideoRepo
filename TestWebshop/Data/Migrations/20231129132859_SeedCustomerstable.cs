using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BillingAddress", "BillingCity", "BillingZip", "DeliveryAddress", "DeliveryCity", "DeliveryZip", "EmailAddress", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Gorvagen", "Finspång", "231D", "Gorvagen", "Finspång", "231D", "123abc@gmail.com", "Spurti", "Salimath", "078675432" },
                    { 2, "Tegelbrukt", "Finspång", "231E", "Gorvagen", "Finspång", "231D", "abc@gmail.com", "Evan", "Andrew", "078675444" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 14, 28, 59, 114, DateTimeKind.Local).AddTicks(7305));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 29, 11, 9, 9, 358, DateTimeKind.Local).AddTicks(798));
        }
    }
}
