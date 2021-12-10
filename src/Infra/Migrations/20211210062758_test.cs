using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeptHistory_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeptHistory_Departments_DepartmentId",
                table: "EmployeeDeptHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDeptHistory",
                table: "EmployeeDeptHistory");

            migrationBuilder.RenameTable(
                name: "EmployeeDeptHistory",
                newName: "EmployeeDeptHistorys");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDeptHistory_FromDate_OfficeId_DepartmentId",
                table: "EmployeeDeptHistorys",
                newName: "IX_EmployeeDeptHistorys_FromDate_OfficeId_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDeptHistory_DepartmentId",
                table: "EmployeeDeptHistorys",
                newName: "IX_EmployeeDeptHistorys_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDeptHistory_ApplicationUserId",
                table: "EmployeeDeptHistorys",
                newName: "IX_EmployeeDeptHistorys_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeId",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDeptHistorys",
                table: "EmployeeDeptHistorys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeptHistorys_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistorys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeptHistorys_Departments_DepartmentId",
                table: "EmployeeDeptHistorys",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeptHistorys_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeptHistorys_Departments_DepartmentId",
                table: "EmployeeDeptHistorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDeptHistorys",
                table: "EmployeeDeptHistorys");

            migrationBuilder.RenameTable(
                name: "EmployeeDeptHistorys",
                newName: "EmployeeDeptHistory");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDeptHistorys_FromDate_OfficeId_DepartmentId",
                table: "EmployeeDeptHistory",
                newName: "IX_EmployeeDeptHistory_FromDate_OfficeId_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDeptHistorys_DepartmentId",
                table: "EmployeeDeptHistory",
                newName: "IX_EmployeeDeptHistory_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDeptHistorys_ApplicationUserId",
                table: "EmployeeDeptHistory",
                newName: "IX_EmployeeDeptHistory_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "AspNetUsers",
                type: "INTEGER",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDeptHistory",
                table: "EmployeeDeptHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeptHistory_AspNetUsers_ApplicationUserId",
                table: "EmployeeDeptHistory",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeptHistory_Departments_DepartmentId",
                table: "EmployeeDeptHistory",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
