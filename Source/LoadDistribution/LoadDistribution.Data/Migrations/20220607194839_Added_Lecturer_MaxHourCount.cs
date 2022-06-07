using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadDistribution.Data.Migrations
{
    public partial class Added_Lecturer_MaxHourCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxHourCount",
                table: "Lecturer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxHourCount",
                table: "Lecturer");
        }
    }
}
