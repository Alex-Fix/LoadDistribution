using Microsoft.EntityFrameworkCore.Migrations;

namespace LoadDistribution.Data.Migrations
{
    public partial class UniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UniversityLecturerMaps_ProjectId",
                table: "UniversityLecturerMaps");

            migrationBuilder.DropIndex(
                name: "IX_LecturerDisciplineActivityMaps_ProjectId",
                table: "LecturerDisciplineActivityMaps");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineActivityMaps_ProjectId",
                table: "DisciplineActivityMaps");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityLecturerMaps_ProjectId_UniversityId_LectureId",
                table: "UniversityLecturerMaps",
                columns: new[] { "ProjectId", "UniversityId", "LectureId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LecturerDisciplineActivityMaps_ProjectId_LecturerId_DisciplineActivityMapId",
                table: "LecturerDisciplineActivityMaps",
                columns: new[] { "ProjectId", "LecturerId", "DisciplineActivityMapId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineActivityMaps_ProjectId_DisciplineId_ActivityId",
                table: "DisciplineActivityMaps",
                columns: new[] { "ProjectId", "DisciplineId", "ActivityId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UniversityLecturerMaps_ProjectId_UniversityId_LectureId",
                table: "UniversityLecturerMaps");

            migrationBuilder.DropIndex(
                name: "IX_LecturerDisciplineActivityMaps_ProjectId_LecturerId_DisciplineActivityMapId",
                table: "LecturerDisciplineActivityMaps");

            migrationBuilder.DropIndex(
                name: "IX_DisciplineActivityMaps_ProjectId_DisciplineId_ActivityId",
                table: "DisciplineActivityMaps");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityLecturerMaps_ProjectId",
                table: "UniversityLecturerMaps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerDisciplineActivityMaps_ProjectId",
                table: "LecturerDisciplineActivityMaps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineActivityMaps_ProjectId",
                table: "DisciplineActivityMaps",
                column: "ProjectId");
        }
    }
}
