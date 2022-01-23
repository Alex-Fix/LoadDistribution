using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoadDistribution.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Details = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeStr = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ExceptionType = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
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
