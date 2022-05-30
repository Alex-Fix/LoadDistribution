using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadDistribution.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Details = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ExceptionType = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    DependencyType = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturer_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                    table.ForeignKey(
                        name: "FK_University_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    Term = table.Column<int>(type: "INTEGER", nullable: false),
                    EducationLevel = table.Column<string>(type: "TEXT", nullable: true),
                    EducationForm = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    PlanIndex = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Speciality = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    GroupAbbreviation = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Institute = table.Column<string>(type: "TEXT", nullable: true),
                    Course = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    BudgetStudentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ComercialStudentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SubgroupCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ThreadCount = table.Column<int>(type: "INTEGER", nullable: false),
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discipline_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discipline_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityLecturerMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    LecturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityLecturerMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityLecturerMap_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityLecturerMap_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityLecturerMap_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineActivityMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisciplineId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineActivityMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineActivityMap_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineActivityMap_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineActivityMap_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ProjectId",
                table: "Activity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_ProjectId",
                table: "Discipline",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_UniversityId",
                table: "Discipline",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineActivityMap_ActivityId",
                table: "DisciplineActivityMap",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineActivityMap_DisciplineId",
                table: "DisciplineActivityMap",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineActivityMap_ProjectId_DisciplineId_ActivityId",
                table: "DisciplineActivityMap",
                columns: new[] { "ProjectId", "DisciplineId", "ActivityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_ProjectId",
                table: "Lecturer",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_University_ProjectId",
                table: "University",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityLecturerMap_LecturerId",
                table: "UniversityLecturerMap",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityLecturerMap_ProjectId_UniversityId_LecturerId",
                table: "UniversityLecturerMap",
                columns: new[] { "ProjectId", "UniversityId", "LecturerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniversityLecturerMap_UniversityId",
                table: "UniversityLecturerMap",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineActivityMap");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "UniversityLecturerMap");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
