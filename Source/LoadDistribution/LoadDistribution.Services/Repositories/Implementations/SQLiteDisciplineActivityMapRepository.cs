using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteDisciplineActivityMapRepository : SQLiteProjectRelatedCollectionRepository<DisciplineActivityMap, SQLiteDbContext>, IDisciplineActivityMapRepository
    {
        #region Constructors
        public SQLiteDisciplineActivityMapRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
