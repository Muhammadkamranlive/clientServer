using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DataAccessLayer.Migrations
{
    public partial class _03UserRoleConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77b4ab5d-2681-4a7e-8eef-f141e51ee86a", "78e2a904-023d-499d-85d4-8edf7ea6c98d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1250f4b8-5b85-4381-8a2c-4bdc9ca534d8", "05d1274a-bcae-41b2-a9a2-ffe93938423d", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16c7a36a-e17f-43a6-a445-ef6dae342b8f", "967154ff-72b1-4cd6-8755-01c07eb4419e", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1250f4b8-5b85-4381-8a2c-4bdc9ca534d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c7a36a-e17f-43a6-a445-ef6dae342b8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b4ab5d-2681-4a7e-8eef-f141e51ee86a");
        }
    }
}
