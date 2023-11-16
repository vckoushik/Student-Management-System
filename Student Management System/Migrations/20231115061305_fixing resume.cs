using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class fixingresume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Resume_ResumeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ResumeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "GPA",
                table: "Resume",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Resume");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ResumeId",
                table: "AspNetUsers",
                column: "ResumeId",
                unique: true,
                filter: "[ResumeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Resume_ResumeId",
                table: "AspNetUsers",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
