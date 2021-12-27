using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class designationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDesignationHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: true),
                    DesignationId = table.Column<int>(type: "INTEGER", nullable: false),
                    FromDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDesignationHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDesignationHistorys_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDesignationHistorys_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignationHistorys_ApplicationUserId",
                table: "EmployeeDesignationHistorys",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignationHistorys_DesignationId",
                table: "EmployeeDesignationHistorys",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignationHistorys_FromDate_ApplicationUserId_DesignationId",
                table: "EmployeeDesignationHistorys",
                columns: new[] { "FromDate", "ApplicationUserId", "DesignationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDesignationHistorys");
        }
    }
}
