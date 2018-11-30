using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eindproject2.Models.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "ID", "category", "date", "planDescription", "planLocation", "planName" },
                values: new object[] { 1, "Concert", new DateTime(2018, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concert van U2 in Antwerpen", "Antwerpen", "Concert" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
