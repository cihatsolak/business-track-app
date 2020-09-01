using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrack.DataAccess.Migrations
{
    public partial class ChangeLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InnerException",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InnerException",
                table: "Logs",
                type: "varchar(MAX)",
                nullable: true);
        }
    }
}
