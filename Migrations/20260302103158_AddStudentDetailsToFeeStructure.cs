using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqCampusHub.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentDetailsToFeeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                table: "FeeStructures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "FeeStructures",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RollNumber",
                table: "FeeStructures");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "FeeStructures");
        }
    }
}
