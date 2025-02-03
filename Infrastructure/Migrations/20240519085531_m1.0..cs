using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("4f7fa932-2d47-4f63-b82a-b73a2d8352ce"));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("cd912af5-7c84-4e5f-9c96-9f6226c13401"), new DateTimeOffset(new DateTime(2024, 5, 19, 8, 55, 30, 948, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("cd912af5-7c84-4e5f-9c96-9f6226c13401"));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("4f7fa932-2d47-4f63-b82a-b73a2d8352ce"), new DateTimeOffset(new DateTime(2024, 5, 14, 6, 0, 11, 35, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });
        }
    }
}
