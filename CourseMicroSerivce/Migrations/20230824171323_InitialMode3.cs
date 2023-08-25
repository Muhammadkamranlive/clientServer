using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseMicroSerivce.Migrations
{
    public partial class InitialMode3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Teacher_startDate",
                table: "AspNetUsers",
                newName: "startingDate");

            migrationBuilder.RenameColumn(
                name: "Teacher_ExpirationDate",
                table: "AspNetUsers",
                newName: "endDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startingDate",
                table: "AspNetUsers",
                newName: "Teacher_startDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "AspNetUsers",
                newName: "Teacher_ExpirationDate");
        }
    }
}
