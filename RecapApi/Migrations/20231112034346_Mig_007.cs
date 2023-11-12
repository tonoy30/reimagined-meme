using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_NXgLrw1YY9iHFt");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Country", "CreatedAt", "IsDeleted", "Name" },
                values: new object[] { "cmp_TMtrWseo08Z2Mk", "1009, Oscar Neer, East Shwerepara, Mirpur, Dhaka-1216", "Bangladesh", new DateTime(2023, 11, 12, 3, 43, 46, 411, DateTimeKind.Utc).AddTicks(9680), false, "ContentCraft" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "cmp_TMtrWseo08Z2Mk");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_NXgLrw1YY9iHFt", 26, null, new DateTime(2023, 11, 12, 2, 53, 28, 215, DateTimeKind.Utc).AddTicks(5900), false, "Tonoy Akanda", "Founder & CTO" });
        }
    }
}
