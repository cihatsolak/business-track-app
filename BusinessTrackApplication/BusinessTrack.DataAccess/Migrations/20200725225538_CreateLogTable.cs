using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessTrack.DataAccess.Migrations
{
    public partial class CreateLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    StackTrase = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    InnerException = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Source = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
