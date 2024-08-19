using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "ID",
                keyValue: new Guid("ab82de93-f2b9-4d39-8e93-0343eea2840a"));

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "ID", "LongUrl", "ShortUrl" },
                values: new object[] { new Guid("f638d5b5-6458-42c3-82a8-0b4869f74b26"), "https://tU/11", "https://testURL/11" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "ID",
                keyValue: new Guid("f638d5b5-6458-42c3-82a8-0b4869f74b26"));

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "ID", "LongUrl", "ShortUrl" },
                values: new object[] { new Guid("ab82de93-f2b9-4d39-8e93-0343eea2840a"), "https://tU/11", "https://testURL/11" });
        }
    }
}
