using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_RegisterOffices_Id",
                table: "Concourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_RegisterOffices_RegisterOfficeId",
                table: "Concourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_TicketOffices_Id",
                table: "Concourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Concourses_TicketOffices_TicketOfficeId",
                table: "Concourses");

            migrationBuilder.DropIndex(
                name: "IX_Concourses_RegisterOfficeId",
                table: "Concourses");

            migrationBuilder.DropIndex(
                name: "IX_Concourses_TicketOfficeId",
                table: "Concourses");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("6f8dc665-f43e-42e4-a176-2926141f2ea4"));

            migrationBuilder.DropColumn(
                name: "RegisterOfficeId",
                table: "Concourses");

            migrationBuilder.DropColumn(
                name: "TicketOfficeId",
                table: "Concourses");

            migrationBuilder.AddColumn<Guid>(
                name: "ConcourseId",
                table: "TicketOffices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcourseId",
                table: "RegisterOffices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("4f7fa932-2d47-4f63-b82a-b73a2d8352ce"), new DateTimeOffset(new DateTime(2024, 5, 14, 6, 0, 11, 35, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketOffices_ConcourseId",
                table: "TicketOffices",
                column: "ConcourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOffices_ConcourseId",
                table: "RegisterOffices",
                column: "ConcourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterOffices_Concourses_ConcourseId",
                table: "RegisterOffices",
                column: "ConcourseId",
                principalTable: "Concourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOffices_Concourses_ConcourseId",
                table: "TicketOffices",
                column: "ConcourseId",
                principalTable: "Concourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterOffices_Concourses_ConcourseId",
                table: "RegisterOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOffices_Concourses_ConcourseId",
                table: "TicketOffices");

            migrationBuilder.DropIndex(
                name: "IX_TicketOffices_ConcourseId",
                table: "TicketOffices");

            migrationBuilder.DropIndex(
                name: "IX_RegisterOffices_ConcourseId",
                table: "RegisterOffices");

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("4f7fa932-2d47-4f63-b82a-b73a2d8352ce"));

            migrationBuilder.DropColumn(
                name: "ConcourseId",
                table: "TicketOffices");

            migrationBuilder.DropColumn(
                name: "ConcourseId",
                table: "RegisterOffices");

            migrationBuilder.AddColumn<Guid>(
                name: "RegisterOfficeId",
                table: "Concourses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketOfficeId",
                table: "Concourses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[] { new Guid("6f8dc665-f43e-42e4-a176-2926141f2ea4"), new DateTimeOffset(new DateTime(2024, 5, 12, 3, 57, 0, 375, DateTimeKind.Unspecified).AddTicks(8046), new TimeSpan(0, 0, 0, 0, 0)), "Default Organization" });

            migrationBuilder.CreateIndex(
                name: "IX_Concourses_RegisterOfficeId",
                table: "Concourses",
                column: "RegisterOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Concourses_TicketOfficeId",
                table: "Concourses",
                column: "TicketOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_RegisterOffices_Id",
                table: "Concourses",
                column: "Id",
                principalTable: "RegisterOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_RegisterOffices_RegisterOfficeId",
                table: "Concourses",
                column: "RegisterOfficeId",
                principalTable: "RegisterOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_TicketOffices_Id",
                table: "Concourses",
                column: "Id",
                principalTable: "TicketOffices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concourses_TicketOffices_TicketOfficeId",
                table: "Concourses",
                column: "TicketOfficeId",
                principalTable: "TicketOffices",
                principalColumn: "Id");
        }
    }
}
