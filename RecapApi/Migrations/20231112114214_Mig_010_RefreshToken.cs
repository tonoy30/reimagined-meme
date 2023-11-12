using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_010_RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "778718bd-ca59-4439-bd25-ca8fa5032ba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c232ddce-052e-49d2-b751-331a211e2773");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_kT8EnuexeL2wah");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_ndUNSBO67hwiYm");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d738ec5-542f-44c6-a492-99f7bd68e78d", null, "Administrator", "ADMINISTRATOR" },
                    { "d0b02f81-56f3-405a-b589-401b3c3c578c", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "cmp_TMtrWseo08Z2Mk",
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 11, 42, 14, 594, DateTimeKind.Utc).AddTicks(5600));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[,]
                {
                    { "emp_fwvrNSGSRyYo0u", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 11, 42, 14, 594, DateTimeKind.Utc).AddTicks(5740), false, "Tonoy Akanda", "Founder & CTO" },
                    { "emp_U2LPZQbYsbwpVG", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 11, 42, 14, 594, DateTimeKind.Utc).AddTicks(5750), false, "Ali Ahmmed", "Founder & CFO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d738ec5-542f-44c6-a492-99f7bd68e78d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0b02f81-56f3-405a-b589-401b3c3c578c");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_fwvrNSGSRyYo0u");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_U2LPZQbYsbwpVG");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "778718bd-ca59-4439-bd25-ca8fa5032ba5", null, "Manager", "MANAGER" },
                    { "c232ddce-052e-49d2-b751-331a211e2773", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "cmp_TMtrWseo08Z2Mk",
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 8, 7, 9, 410, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[,]
                {
                    { "emp_kT8EnuexeL2wah", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 8, 7, 9, 410, DateTimeKind.Utc).AddTicks(6070), false, "Ali Ahmmed", "Founder & CFO" },
                    { "emp_ndUNSBO67hwiYm", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 8, 7, 9, 410, DateTimeKind.Utc).AddTicks(6060), false, "Tonoy Akanda", "Founder & CTO" }
                });
        }
    }
}
