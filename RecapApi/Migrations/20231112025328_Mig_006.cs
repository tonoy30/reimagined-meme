using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Company_CompanyId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_OnJez6Izc26tBz");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_NXgLrw1YY9iHFt", 26, null, new DateTime(2023, 11, 12, 2, 53, 28, 215, DateTimeKind.Utc).AddTicks(5900), false, "Tonoy Akanda", "Founder & CTO" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_NXgLrw1YY9iHFt");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_OnJez6Izc26tBz", 26, null, new DateTime(2023, 11, 12, 2, 11, 18, 632, DateTimeKind.Utc).AddTicks(3220), false, "Tonoy Akanda", "Founder & CTO" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Company_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
