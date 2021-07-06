using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class Sw_HW_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Software",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Software",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Software",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Software",
                nullable: true,
                oldClrType: typeof(int));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
