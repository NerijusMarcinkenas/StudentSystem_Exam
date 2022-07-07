using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem_Repository.Migrations
{
    public partial class StudentPersonalCodeStringType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonalCode",
                table: "Students",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PersonalCode",
                table: "Students",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }
    }
}
