using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class Department_Nullable_inSW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Software",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Department_DepartmentId",
                table: "Software",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
