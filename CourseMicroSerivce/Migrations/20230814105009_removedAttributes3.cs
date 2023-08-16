using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseMicroSerivce.Migrations
{
    public partial class removedAttributes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchooleQuizId",
                table: "QuizPosts",
                newName: "chapterId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "QuizPosts",
                newName: "questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "questions",
                table: "QuizPosts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "chapterId",
                table: "QuizPosts",
                newName: "SchooleQuizId");
        }
    }
}
