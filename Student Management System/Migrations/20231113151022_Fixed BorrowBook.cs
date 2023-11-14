using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class FixedBorrowBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_AspNetUsers_studentId",
                table: "Registration");

            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Course_courseId",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Registration",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "Registration",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_studentId",
                table: "Registration",
                newName: "IX_Registration_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_courseId",
                table: "Registration",
                newName: "IX_Registration_CourseId");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCopies",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalCopies",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BorrowBooks",
                columns: table => new
                {
                    BorrowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BookBNo = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowBooks", x => x.BorrowID);
                    table.ForeignKey(
                        name: "FK_BorrowBooks_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BorrowBooks_Book_BookBNo",
                        column: x => x.BookBNo,
                        principalTable: "Book",
                        principalColumn: "BNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BookBNo",
                table: "BorrowBooks",
                column: "BookBNo");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_StudentId",
                table: "BorrowBooks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_AspNetUsers_StudentId",
                table: "Registration",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Course_CourseId",
                table: "Registration",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_AspNetUsers_StudentId",
                table: "Registration");

            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Course_CourseId",
                table: "Registration");

            migrationBuilder.DropTable(
                name: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "AvailableCopies",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "TotalCopies",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Registration",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Registration",
                newName: "courseId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_StudentId",
                table: "Registration",
                newName: "IX_Registration_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_CourseId",
                table: "Registration",
                newName: "IX_Registration_courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_AspNetUsers_studentId",
                table: "Registration",
                column: "studentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Course_courseId",
                table: "Registration",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
