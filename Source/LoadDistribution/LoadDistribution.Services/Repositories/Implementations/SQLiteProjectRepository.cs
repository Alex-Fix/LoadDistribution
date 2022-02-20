using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteProjectRepository : SQLiteCollectionRepository<Project, SQLiteDbContext>, IProjectRepository
    {
        #region Constructors
        public SQLiteProjectRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
