using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class bossUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BossUserId",
                table: "AspNetUsers",
                column: "BossUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BossUserId",
                table: "AspNetUsers",
                column: "BossUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BossUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BossUserId",
                table: "AspNetUsers");
        }
    }
}
