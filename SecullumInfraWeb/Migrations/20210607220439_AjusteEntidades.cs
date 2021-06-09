using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class AjusteEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Software",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "Configuration",
                table: "Hardware",
                newName: "Processor");

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Software",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HdSsd",
                table: "Hardware",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ram",
                table: "Hardware",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Software");

            migrationBuilder.DropColumn(
                name: "HdSsd",
                table: "Hardware");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Hardware");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Software",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "Processor",
                table: "Hardware",
                newName: "Configuration");
        }
    }
}
