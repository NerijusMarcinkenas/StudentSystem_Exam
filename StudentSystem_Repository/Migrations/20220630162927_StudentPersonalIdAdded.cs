using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem_Repository.Migrations
{
    public partial class StudentPersonalIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PersonalCode",
                table: "Students",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalCode",
                table: "Students");
        }
    }
}
