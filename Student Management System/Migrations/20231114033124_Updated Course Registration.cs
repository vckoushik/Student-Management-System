using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCourseRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistration_AspNetUsers_StudentId1",
                table: "CourseRegistration");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistration_StudentId1",
                table: "CourseRegistration");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "CourseRegistration");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "CourseRegistration",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CourseRegistration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistration_StudentId",
                table: "CourseRegistration",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistration_AspNetUsers_StudentId",
                table: "CourseRegistration",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistration_AspNetUsers_StudentId",
                table: "CourseRegistration");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistration_StudentId",
                table: "CourseRegistration");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CourseRegistration");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "CourseRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "CourseRegistration",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistration_StudentId1",
                table: "CourseRegistration",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistration_AspNetUsers_StudentId1",
                table: "CourseRegistration",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
