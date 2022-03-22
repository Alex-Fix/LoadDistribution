using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Interfaces;
using LoadDistribution.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace LoadDistribution.Data
{
    public class SQLiteDbContext : DbContext, IDbContext
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

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(_dbOptions.ConnectionString)
                .UseLazyLoadingProxies()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SQLiteDbContext).Assembly);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity => base.Set<TEntity>();
        #endregion
    }
}
