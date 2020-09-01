using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrack.DataAccess.Migrations
{
    public partial class AppUserAssignmetEROneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AppUserId",
                table: "Assignments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_AppUserId",
                table: "Assignments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_AppUserId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AppUserId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
