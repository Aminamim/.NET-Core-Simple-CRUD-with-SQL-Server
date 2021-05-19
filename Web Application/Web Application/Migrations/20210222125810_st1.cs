using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Application.Migrations
{
    public partial class st1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "StudentInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "StudentInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "StudentInfos");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "StudentInfos");
        }
    }
}
