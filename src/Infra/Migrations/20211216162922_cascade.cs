using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeptHistorys_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistorys");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeptHistorys_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistorys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeptHistorys_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistorys");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeptHistorys_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistorys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
