using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Fixedstudentref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_AspNetUsers_StudentId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Registration_AspNetUsers_StudentId",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Registration",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_StudentId",
                table: "Registration",
                newName: "IX_Registration_UserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "BorrowBooks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_StudentId",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_AspNetUsers_UserId",
                table: "BorrowBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_AspNetUsers_UserId",
                table: "Registration",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_AspNetUsers_UserId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Registration_AspNetUsers_UserId",
                table: "Registration");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Registration",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Registration_UserId",
                table: "Registration",
                newName: "IX_Registration_StudentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BorrowBooks",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_AspNetUsers_StudentId",
                table: "BorrowBooks",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_AspNetUsers_StudentId",
                table: "Registration",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
