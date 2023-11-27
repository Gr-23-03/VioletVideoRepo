using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "ImageURL", "Price", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, " Christopher McQuarrie", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fthedailyguardian.com%2Fmission-impossible-dead-reckoning-part-one%2F&psig=AOvVaw27TCwGYi98csvR-I9ttZ2m&ust=1701096883765000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCICusu714YIDFQAAAAAdAAAAABAE", 129m, 2023, "Mission Impossible" },
                    { 2, "Tom Harper", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt13603966%2F&psig=AOvVaw0XQE71_lOUgZELqCt4Xsd6&ust=1701096791642000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCLD0xsL14YIDFQAAAAAdAAAAABAE", 299m, 2023, "Heart of Stone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
