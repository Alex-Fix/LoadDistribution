using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteDisciplineActivityMapRepository : SQLiteRepository<DisciplineActivityMap, SQLiteDbContext>, IDisciplineActivityMapRepository
    {
        #region Fields
        private readonly SQLiteDbContext _dbContext;
        #endregion

        #region Constructors
        public SQLiteDisciplineActivityMapRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
    }
}
