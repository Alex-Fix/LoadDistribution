using LoadDistribution.Core.Domain.Models;
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
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<Paged<TEntity>> GetPaged(int pageNumber, int pageSize)
        {
            return await Paged<TEntity>.Build(_dbContext.Set<TEntity>(), pageNumber, pageSize);
        }
        #endregion
    }
}
