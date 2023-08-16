using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseMicroSerivce.Migrations
{
    public partial class removedAttributes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "PermissionManagments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "PermissionManagments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
