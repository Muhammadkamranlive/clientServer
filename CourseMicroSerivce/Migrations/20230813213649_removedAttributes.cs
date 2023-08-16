using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseMicroSerivce.Migrations
{
    public partial class removedAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "PermissionManagments");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "PermissionManagments");

            migrationBuilder.DropColumn(
                name: "chapterId",
                table: "PermissionManagments");

            migrationBuilder.DropColumn(
                name: "themeId",
                table: "PermissionManagments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "PermissionManagments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "PermissionManagments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "chapterId",
                table: "PermissionManagments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "themeId",
                table: "PermissionManagments",
                type: "int",
                nullable: true);
        }
    }
}
