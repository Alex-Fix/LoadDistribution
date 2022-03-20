using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public abstract class SQLiteCollectionRepository<TEntity, TContext> : SQLiteRepository<TEntity, TContext>, ICollectionRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        #region Constructors
        public SQLiteCollectionRepository(TContext context) : base(context)
        {
        }
        #endregion

        #region Methods
        public async virtual Task<IList<TEntity>> GetAll()
        {
            var query = _dbContext.Set<TEntity>();
            return await Sort(query).ToListAsync();
        }

        public async virtual Task<Paged<TEntity>> GetPaged(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<TEntity>();
            return await Paged<TEntity>.Build(Sort(query), pageNumber, pageSize);
        }
        #endregion
    }
}
