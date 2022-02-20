using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Data;
using System;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteLecturerDisciplineActivityMapRepository : SQLiteProjectRelatedCollectionRepository<LecturerDisciplineActivityMap, SQLiteDbContext>, ILecturerDisciplineActivityMapRepository
    {
        #region Constructors
        public SQLiteLecturerDisciplineActivityMapRepository(SQLiteDbContext dbContext) : base(dbContext)
        {
        }
        #endregion
    }
}
