using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrack.DataAccess.Migrations
{
    public partial class CreateTableExigency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExigencyId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exigencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exigencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ExigencyId",
                table: "Assignments",
                column: "ExigencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Exigencies_ExigencyId",
                table: "Assignments",
                column: "ExigencyId",
                principalTable: "Exigencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Exigencies_ExigencyId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "Exigencies");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_ExigencyId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ExigencyId",
                table: "Assignments");
        }
    }
}
