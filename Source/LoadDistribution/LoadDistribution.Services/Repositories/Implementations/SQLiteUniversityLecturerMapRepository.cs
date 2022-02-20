using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteUniversityLecturerMapRepository : SQLiteProjectRelatedCollectionRepository<UniversityLecturerMap, SQLiteDbContext>, IUniversityLecturerMapRepository
    {
        #region Constructors
        public SQLiteUniversityLecturerMapRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
