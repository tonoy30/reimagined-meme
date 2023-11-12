using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecapApi.Migrations
{
    /// <inheritdoc />
    public partial class Mig_009_Identity_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_Jvxm0eHvIISusz");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "emp_mq2R8aEd9zbVdv");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: "cmp_TMtrWseo08Z2Mk",
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 8, 0, 8, 875, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "CreatedAt", "IsDeleted", "Name", "Position" },
                values: new object[,]
                {
                    { "emp_Jvxm0eHvIISusz", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 8, 0, 8, 875, DateTimeKind.Utc).AddTicks(5660), false, "Ali Ahmmed", "Founder & CFO" },
                    { "emp_mq2R8aEd9zbVdv", 26, "cmp_TMtrWseo08Z2Mk", new DateTime(2023, 11, 12, 8, 0, 8, 875, DateTimeKind.Utc).AddTicks(5650), false, "Tonoy Akanda", "Founder & CTO" }
                });
        }
    }
}
