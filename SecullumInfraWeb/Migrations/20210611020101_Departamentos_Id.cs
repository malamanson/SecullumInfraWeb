using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class Departamentos_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Software",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Hardware",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware");

            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Software",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Hardware",
                nullable: true,
                oldClrType: typeof(int));

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
        }
    }
}
