using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecullumInfraWeb.Migrations
{
    public partial class NovasEtidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Hardware",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Hardware",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Hardware",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    HardwareId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Software_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Software_Hardware_HardwareId",
                        column: x => x.HardwareId,
                        principalTable: "Hardware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hardware_DepartmentId",
                table: "Hardware",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Software_DepartmentId",
                table: "Software",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Software_HardwareId",
                table: "Software",
                column: "HardwareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hardware_Department_DepartmentId",
                table: "Hardware");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Hardware_DepartmentId",
                table: "Hardware");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Hardware");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Hardware");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Hardware");
        }
    }
}
