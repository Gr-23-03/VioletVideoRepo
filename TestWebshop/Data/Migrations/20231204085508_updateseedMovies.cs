using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateseedMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "https://media.ginza.se/Images/item_img_150/15084.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageURL",
                value: "https://media.ginza.se/Images/item_img_150/138194.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURL",
                value: "https://media.ginza.se/Images/item_img_150/13909.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageURL",
                value: "https://media.ginza.se/Images/item_img_150/409994.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageURL",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthedailyguardian.com%2Fmission-impossible-dead-reckoning-part-one%2F&psig=AOvVaw27TCwGYi98csvR-I9ttZ2m&ust=1701096883765000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCICusu714YIDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageURL",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt13603966%2F&psig=AOvVaw0XQE71_lOUgZELqCt4Xsd6&ust=1701096791642000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCLD0xsL14YIDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageURL",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0098635%2F&psig=AOvVaw3Au9W4p6cLjjvgaDHpHjAN&ust=1701107299984000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCLDXhdWc4oIDFQAAAAAdAAAAABAE");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageURL",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0087332%2F&psig=AOvVaw2rGeYGMa_IcNckkUqqUKqN&ust=1701107357993000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCID-0_Cc4oIDFQAAAAAdAAAAABAK");
        }
    }
}
