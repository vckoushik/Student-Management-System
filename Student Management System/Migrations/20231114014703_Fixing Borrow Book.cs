using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class FixingBorrowBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Book_BookBNo",
                table: "BorrowBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_BookBNo",
                table: "BorrowBooks");

            migrationBuilder.RenameColumn(
                name: "BookBNo",
                table: "BorrowBooks",
                newName: "BookNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookNo",
                table: "BorrowBooks",
                newName: "BookBNo");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_BookBNo",
                table: "BorrowBooks",
                column: "BookBNo");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Book_BookBNo",
                table: "BorrowBooks",
                column: "BookBNo",
                principalTable: "Book",
                principalColumn: "BNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
