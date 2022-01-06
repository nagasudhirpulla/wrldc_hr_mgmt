using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class DEsignationGradeDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Designations_Grade",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Designations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Designations",
                type: "TEXT",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_Grade",
                table: "Designations",
                column: "Grade",
                unique: true);
        }
    }
}
