using LoadDistribution.Core.Domain;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Options;
using LoadDistribution.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoadDistribution.Data
{
    public class MySqlDbContext : DbContext, IDbContext
    {
        #region Private Fields
        private readonly MySqlDbOptions _dbOptions;
        #endregion

        #region Constructors
        public MySqlDbContext(IOptions<MySqlDbOptions> dbOptions)
        {
            _dbOptions = dbOptions.Value;
        }
        #endregion

        #region Public Properties
        public DbSet<Log> Logs { get; set; }
        #endregion

        #region Protected Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(_dbOptions.ConnectionString, new MySqlServerVersion(_dbOptions.ServerVersion))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogConfiguration());
        }
        #endregion
    }
}
