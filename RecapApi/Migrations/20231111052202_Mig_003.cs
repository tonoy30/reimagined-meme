using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_Xmp1IKUCPNqtSp");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Company",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_YqONrraKDzMn9P", 26, new DateTime(2023, 11, 11, 5, 22, 2, 239, DateTimeKind.Utc).AddTicks(2150), false, "Tonoy Akanda", "Founder & CTO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_YqONrraKDzMn9P");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Company");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_Xmp1IKUCPNqtSp", 26, false, "Tonoy Akanda", "Founder & CTO" });
        }
    }
}
