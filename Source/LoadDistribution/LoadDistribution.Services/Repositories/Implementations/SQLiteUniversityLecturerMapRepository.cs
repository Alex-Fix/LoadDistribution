using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteUniversityLecturerMapRepository : SQLiteRepository<UniversityLecturerMap, SQLiteDbContext>, IUniversityLecturerMapRepository
    {
        #region Fields
        private readonly SQLiteDbContext _dbContext;
        #endregion

        #region Constructors
        public SQLiteUniversityLecturerMapRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
    }
}
