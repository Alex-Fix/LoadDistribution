using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteLogRepository : SQLiteCollectionRepository<Log, SQLiteDbContext>, ILogRepository
    {
        #region Constructors
        public SQLiteLogRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
