using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteDisciplineRepository : SQLiteProjectRelatedCollectionRepository<Discipline, SQLiteDbContext>, IDisciplineRepository
    {
        #region Constructors
        public SQLiteDisciplineRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
