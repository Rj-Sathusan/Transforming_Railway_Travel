using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRY.Migrations
{
    public partial class iniuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(59)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
