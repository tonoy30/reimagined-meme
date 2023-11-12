using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_XSxyt2Hs6dRZTP");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Company",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_OnJez6Izc26tBz", 26, null, new DateTime(2023, 11, 12, 2, 11, 18, 632, DateTimeKind.Utc).AddTicks(3220), false, "Tonoy Akanda", "Founder & CTO" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Company_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Company_CompanyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_OnJez6Izc26tBz");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Company");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[] { "emp_XSxyt2Hs6dRZTP", 26, new DateTime(2023, 11, 11, 5, 26, 40, 569, DateTimeKind.Utc).AddTicks(9970), false, "Tonoy Akanda", "Founder & CTO" });
        }
    }
}
