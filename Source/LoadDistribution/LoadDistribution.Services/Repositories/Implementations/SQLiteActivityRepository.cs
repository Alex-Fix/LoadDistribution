using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteActivityRepository : SQLiteProjectRelatedCollectionRepository<Activity, SQLiteDbContext>, IActivityRepository
    {
        #region Constructors
        public SQLiteActivityRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
