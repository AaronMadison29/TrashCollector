using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class OneTimePickupAddedToServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27261bbe-eca9-41a3-8d03-bbd2c1ff4052");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbf7113a-a04e-4e76-a330-ca0a34fd9e7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7dec47d-69a8-4395-ac23-e210395bbb7e");

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickup",
                table: "Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "503667ee-8c45-45ec-843e-4f3161d8a273", "b7c1d9fe-eaa6-49ab-b621-04c73f0dc1d8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2283dadb-3970-4f1a-a3f2-0ebaf84e1468", "7d450a5f-2bc8-482a-ae8b-49d57de1323c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e14d10b4-d13e-4897-b661-b3b1db5dc354", "0d3a0500-7737-4dc8-aa1a-cfc11c944c35", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2283dadb-3970-4f1a-a3f2-0ebaf84e1468");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "503667ee-8c45-45ec-843e-4f3161d8a273");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e14d10b4-d13e-4897-b661-b3b1db5dc354");

            migrationBuilder.DropColumn(
                name: "OneTimePickup",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbf7113a-a04e-4e76-a330-ca0a34fd9e7f", "905fa038-6460-40a3-8061-bbd7923a3eeb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27261bbe-eca9-41a3-8d03-bbd2c1ff4052", "067f4b37-5db6-4520-84ff-539d44f1c318", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7dec47d-69a8-4395-ac23-e210395bbb7e", "d8befd96-fcd1-4010-bf10-95b735443583", "Employee", "EMPLOYEE" });
        }
    }
}
