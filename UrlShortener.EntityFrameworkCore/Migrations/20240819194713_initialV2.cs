using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "ID",
                keyValue: new Guid("47fef85d-158b-4d94-9cbb-f3e88ff4e0b0"));

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "ID", "LongUrl", "ShortUrl" },
                values: new object[] { new Guid("ab82de93-f2b9-4d39-8e93-0343eea2840a"), "https://tU/11", "https://testURL/11" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "ID",
                keyValue: new Guid("ab82de93-f2b9-4d39-8e93-0343eea2840a"));

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "ID", "LongUrl", "ShortUrl" },
                values: new object[] { new Guid("47fef85d-158b-4d94-9cbb-f3e88ff4e0b0"), "emre", "berkay" });
        }
    }
}
