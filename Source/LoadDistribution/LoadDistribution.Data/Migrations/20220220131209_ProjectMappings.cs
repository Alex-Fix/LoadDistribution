using Microsoft.EntityFrameworkCore.Migrations;

namespace LoadDistribution.Data.Migrations
{
    public partial class ProjectMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "UniversityLecturerMaps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Lecturers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "LecturerDisciplineActivityMaps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Disciplines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "DisciplineActivityMaps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Activities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityLecturerMaps_ProjectId",
                table: "UniversityLecturerMaps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_ProjectId",
                table: "Lecturers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerDisciplineActivityMaps_ProjectId",
                table: "LecturerDisciplineActivityMaps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineActivityMaps_ProjectId",
                table: "DisciplineActivityMaps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ProjectId",
                table: "Activities",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                table: "Activities",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineActivityMaps_Projects_ProjectId",
                table: "DisciplineActivityMaps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Projects_ProjectId",
                table: "Disciplines",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerDisciplineActivityMaps_Projects_ProjectId",
                table: "LecturerDisciplineActivityMaps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Projects_ProjectId",
                table: "Lecturers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityLecturerMaps_Projects_ProjectId",
                table: "UniversityLecturerMaps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineActivityMaps_Projects_ProjectId",
                table: "DisciplineActivityMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Projects_ProjectId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerDisciplineActivityMaps_Projects_ProjectId",
                table: "LecturerDisciplineActivityMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Projects_ProjectId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityLecturerMaps_Projects_ProjectId",
                table: "UniversityLecturerMaps");

            migrationBuilder.DropIndex(
                name: "IX_UniversityLecturerMaps_ProjectId",
                table: "UniversityLecturerMaps");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_ProjectId",
                table: "Lecturers");

            migrationBuilder.DropIndex(
                name: "IX_LecturerDisciplineActivityMaps_ProjectId",
                table: "LecturerDisciplineActivityMaps");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineActivityMaps_ProjectId",
                table: "DisciplineActivityMaps");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ProjectId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "UniversityLecturerMaps");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "LecturerDisciplineActivityMaps");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "DisciplineActivityMaps");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Activities");
        }
    }
}
