using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class DefaultValueTrueIsActiveServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93a68f92-cd18-4830-8e84-5b37b6f8d8fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d08dd7f4-5f1b-437d-9253-399d0e5c5502");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3cccd0b-219a-4f4a-8a32-924529ba9fc9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6106575-5c43-40c2-b8df-fa4a843b13cd", "bf1d65af-033d-456d-a155-de41091fc045", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96050a12-d851-45db-96fa-e5917b724a9a", "3894ed14-404e-4f5e-8c72-c09d7ac59679", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65f3085c-c00c-435e-bfce-65fa94951ced", "25879e27-e3bf-4057-8f93-f4c7fdcf6b8b", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f3085c-c00c-435e-bfce-65fa94951ced");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96050a12-d851-45db-96fa-e5917b724a9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6106575-5c43-40c2-b8df-fa4a843b13cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3cccd0b-219a-4f4a-8a32-924529ba9fc9", "f4e7eae1-9538-47a9-8401-78035a410cc3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93a68f92-cd18-4830-8e84-5b37b6f8d8fd", "06813278-7116-4ab6-bdb9-64aed9483ac9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d08dd7f4-5f1b-437d-9253-399d0e5c5502", "9c89eaab-eab6-4e4a-865b-740b242a599e", "Employee", "EMPLOYEE" });
        }
    }
}
