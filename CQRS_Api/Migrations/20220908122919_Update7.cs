using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRS_Api.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpName",
                table: "Employees",
                newName: "EmpLastName");

            migrationBuilder.AddColumn<string>(
                name: "EmpFirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpFirstName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmpLastName",
                table: "Employees",
                newName: "EmpName");
        }
    }
}
