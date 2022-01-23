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
    public class SQLiteDbContext : DbContext, IDbContext
    {
        #region Private Fields
        private readonly SQLiteDbOptions _dbOptions;
        #endregion

        #region Constructor
        public SQLiteDbContext(IOptions<SQLiteDbOptions> dbOptions)
        {
            _dbOptions = dbOptions?.Value ?? throw new ArgumentNullException(nameof(dbOptions));
        }
        #endregion

        #region Public Properties
        public DbSet<Log> Logs { get; set; }
        #endregion

        #region Protected Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(_dbOptions.ConnectionString)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogConfiguration());
        }
        #endregion

        #region Public Methods
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
