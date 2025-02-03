using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("925f22a5-ad20-492a-90a6-87d1d7ac7d3a"), new DateTimeOffset(new DateTime(2024, 5, 12, 2, 52, 33, 203, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("925f22a5-ad20-492a-90a6-87d1d7ac7d3a"));
        }
    }
}
