using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class Hardware_in_Software : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Software",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "Software",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Software_Hardware_HardwareId",
                table: "Software",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
