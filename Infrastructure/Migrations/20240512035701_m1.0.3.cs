using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_RegisterOffices_Id",
                table: "Concourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_TicketOffices_Id",
                table: "Concourses");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("925f22a5-ad20-492a-90a6-87d1d7ac7d3a"));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("6f8dc665-f43e-42e4-a176-2926141f2ea4"), new DateTimeOffset(new DateTime(2024, 5, 12, 3, 57, 0, 375, DateTimeKind.Unspecified).AddTicks(8046), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_RegisterOffices_Id",
                table: "Concourses",
                column: "Id",
                principalTable: "RegisterOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_TicketOffices_Id",
                table: "Concourses",
                column: "Id",
                principalTable: "TicketOffices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_RegisterOffices_Id",
                table: "Concourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_TicketOffices_Id",
                table: "Concourses");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("6f8dc665-f43e-42e4-a176-2926141f2ea4"));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("925f22a5-ad20-492a-90a6-87d1d7ac7d3a"), new DateTimeOffset(new DateTime(2024, 5, 12, 2, 52, 33, 203, DateTimeKind.Unspecified).AddTicks(1962), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_RegisterOffices_Id",
                table: "Concourses",
                column: "Id",
                principalTable: "RegisterOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_TicketOffices_Id",
                table: "Concourses",
                column: "Id",
                principalTable: "TicketOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
