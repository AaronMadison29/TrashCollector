using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Data.Migrations
{
    public partial class AddedPickedUpVariableToServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "PickedUp",
                table: "Services",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "184848bf-db72-40f6-acbd-35be4d8388f0", "31060f83-944b-4b02-b171-51add5794062", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfa9a6fa-c481-4d6b-84a7-eca8f1ee9f68", "d06720ed-a92c-483f-a6d2-94144fd08f04", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db640e93-3a67-4325-876b-f3a931c686fd", "811af7cb-9649-4128-a188-e7e16f754fca", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "184848bf-db72-40f6-acbd-35be4d8388f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db640e93-3a67-4325-876b-f3a931c686fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfa9a6fa-c481-4d6b-84a7-eca8f1ee9f68");

            migrationBuilder.DropColumn(
                name: "PickedUp",
                table: "Services");

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
    }
}
