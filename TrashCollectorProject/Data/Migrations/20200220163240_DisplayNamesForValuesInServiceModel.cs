using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class DisplayNamesForValuesInServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
