using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class grade_uniq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Designations_Grade",
                table: "Designations",
                column: "Grade",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Designations_Grade",
                table: "Designations");
        }
    }
}
