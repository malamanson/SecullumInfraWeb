using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class db_Alter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software");

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software");

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
