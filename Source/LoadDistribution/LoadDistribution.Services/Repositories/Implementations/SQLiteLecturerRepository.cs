using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteLecturerRepository : SQLiteProjectRelatedCollectionRepository<Lecturer, SQLiteDbContext>, ILecturerRepository
    {
        #region Constructors
        public SQLiteLecturerRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
