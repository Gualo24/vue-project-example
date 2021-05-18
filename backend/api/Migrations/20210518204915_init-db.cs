using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNames = table.Column<string>(type: "varchar(200)", nullable: false),
                    EmployeeLastName = table.Column<string>(type: "varchar(200)", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    PermissionDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionType",
                        column: x => x.PermissionType,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Enfermedad," });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Diligencias" });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Otros." });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionType",
                table: "Permissions",
                column: "PermissionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTypes");
        }
    }
}
