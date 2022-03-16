using LoadDistribution.Core.Domain;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace LoadDistribution.Data
{
    public class SQLiteDbContext : DbContext
    {
        #region Fields
        private readonly SQLiteDbOptions _dbOptions;
        #endregion

        #region Constructors
        public SQLiteDbContext(IOptions<SQLiteDbOptions> dbOptions)
        {
            _dbOptions = dbOptions?.Value ?? throw new ArgumentNullException(nameof(dbOptions));
        }
        #endregion

        #region Properties
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineActivityMap> DisciplineActivityMaps { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<LecturerDisciplineActivityMap> LecturerDisciplineActivityMaps { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityLecturerMap> UniversityLecturerMaps { get; set; }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(_dbOptions.ConnectionString)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            SaveChangesFailed += (_, _) => ChangeTracker.Clear();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SQLiteDbContext).Assembly);
        }
        #endregion
    }
}
