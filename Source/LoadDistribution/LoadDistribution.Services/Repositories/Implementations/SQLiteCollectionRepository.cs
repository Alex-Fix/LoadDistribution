﻿using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteCollectionRepository<TEntity> : SQLiteRepository<TEntity>, ICollectionRepository<TEntity> where TEntity : class, IEntity
    {
        #region Constructors
        public SQLiteCollectionRepository(IDbContext context) : base(context)
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
