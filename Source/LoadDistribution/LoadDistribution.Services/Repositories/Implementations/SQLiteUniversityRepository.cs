using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteUniversityRepository : SQLiteRepository<University, SQLiteDbContext>, IUniversityRepository
    {
        #region Fields
        private readonly SQLiteDbContext _dbContext;
        #endregion

        #region Constructors
        public SQLiteUniversityRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion
    }
}
