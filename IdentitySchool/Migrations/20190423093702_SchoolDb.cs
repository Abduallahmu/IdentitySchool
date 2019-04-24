using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentitySchool.Migrations
{
    public partial class SchoolDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "StudentsCourses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId1",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Assignments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_AssignmentId",
                table: "StudentsCourses",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentId1",
                table: "Assignments",
                column: "AssignmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Assignments_AssignmentId1",
                table: "Assignments",
                column: "AssignmentId1",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Assignments_AssignmentId",
                table: "StudentsCourses",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Assignments_AssignmentId1",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Assignments_AssignmentId",
                table: "StudentsCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourses_AssignmentId",
                table: "StudentsCourses");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AssignmentId1",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "StudentsCourses");

            migrationBuilder.DropColumn(
                name: "AssignmentId1",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
