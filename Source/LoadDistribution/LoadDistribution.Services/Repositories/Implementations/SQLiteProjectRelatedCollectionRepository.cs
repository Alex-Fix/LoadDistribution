using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public abstract class SQLiteProjectRelatedCollectionRepository<TEntity, TContext> : SQLiteRepository<TEntity, TContext>, IProjectRelatedCollectionRepository<TEntity>
        where TEntity : class, IProjectRelatedEntity
        where TContext : DbContext
    {
        #region Constructors
        public SQLiteProjectRelatedCollectionRepository(TContext context) : base(context)
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
