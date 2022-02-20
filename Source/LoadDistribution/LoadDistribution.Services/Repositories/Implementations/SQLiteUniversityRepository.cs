using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteUniversityRepository : SQLiteProjectRelatedCollectionRepository<University, SQLiteDbContext>, IUniversityRepository
    {
        #region Constructors
        public SQLiteUniversityRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
