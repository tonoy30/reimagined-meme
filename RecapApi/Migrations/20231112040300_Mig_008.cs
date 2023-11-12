using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "cmp_TMtrWseo08Z2Mk",
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 4, 3, 0, 317, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[,]
                {
                    { "emp_jUwTGvLv7gABXw", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 4, 3, 0, 317, DateTimeKind.Utc).AddTicks(8530), false, "Tonoy Akanda", "Founder & CTO" },
                    { "emp_rSy1VmOkK8Amo4", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 4, 3, 0, 317, DateTimeKind.Utc).AddTicks(8540), false, "Ali Ahmmed", "Founder & CFO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_jUwTGvLv7gABXw");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_rSy1VmOkK8Amo4");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "cmp_TMtrWseo08Z2Mk",
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 3, 43, 46, 411, DateTimeKind.Utc).AddTicks(9680));
        }
    }
}
