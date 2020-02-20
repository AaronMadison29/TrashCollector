using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class NullableDataInServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspensionStart",
                table: "Services",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspensionEnd",
                table: "Services",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OneTimePickup",
                table: "Services",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2a3e6ee-d1cb-45b0-9e6c-c581c36cac30", "b80d344d-c798-4797-be7b-0bed517098d2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6af0a7c-84a3-40eb-add5-5f3b39fcaf55", "6ad488db-659c-419f-88cf-ba70ebca8126", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0838662-6288-4b3b-980f-dc5cfc30bab1", "4f098073-c5d6-402a-ade1-85a11957c9b5", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6af0a7c-84a3-40eb-add5-5f3b39fcaf55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0838662-6288-4b3b-980f-dc5cfc30bab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a3e6ee-d1cb-45b0-9e6c-c581c36cac30");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspensionStart",
                table: "Services",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspensionEnd",
                table: "Services",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OneTimePickup",
                table: "Services",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
    }
}
