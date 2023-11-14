using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Fixedstudentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_AspNetUsers_UserId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Registration_AspNetUsers_UserId",
                table: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Registration_UserId",
                table: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BorrowBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registration",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BorrowBooks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_UserId",
                table: "Registration",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks",
                column: "UserId");

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
    }
}
