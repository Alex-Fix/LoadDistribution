using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteProjectRelatedCollectionRepository<TEntity> : SQLiteRepository<TEntity>, IProjectRelatedCollectionRepository<TEntity> where TEntity : class, IProjectRelatedEntity
    {
        #region Constructors
        public SQLiteProjectRelatedCollectionRepository(IDbContext context) : base(context)
        {
        }
        #endregion

        #region Methods
        public async virtual Task<IList<TEntity>> GetAll(int projectId)
        {
            var query = _dbContext.Set<TEntity>().Where(entity => entity.ProjectId == projectId);
            return await Sort(query).ToListAsync();
        }

        public async virtual Task<Paged<TEntity>> GetPaged(int projectId, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<TEntity>().Where(entity => entity.ProjectId == projectId);
            return await Paged<TEntity>.Build(Sort(query), pageNumber, pageSize);
        }
        #endregion
    }
}
