using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public class SQLiteRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Fields
        protected readonly IDbContext _dbContext;
        #endregion

        #region Constructors
        public SQLiteRepository(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion

        #region Methods
        public async virtual Task<TEntity> Get(int id)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<InsertResult> Insert(TEntity entity)
        {
            if(entity is null)
            {
                return new InsertResult(null, false);
            }

            if(entity is ICreateble creatable)
            {
                creatable.Created = DateTimeOffset.UtcNow;
            }
            if(entity is IUpdateble updateble)
            {
                updateble.Updated = DateTimeOffset.UtcNow;
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return new InsertResult(entity.Id, true);
            }
            catch
            {
                await transaction.RollbackAsync();
                _dbContext.ChangeTracker.Clear();
                throw;
            }
        }

        public async virtual Task<bool> Update(TEntity entity)
        {
            if(entity is null)
            {
                return false;
            }

            if(entity is IUpdateble updateble)
            {
                updateble.Updated = DateTimeOffset.UtcNow;
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                _dbContext.ChangeTracker.Clear();
                throw;
            }
        }

        public async virtual Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
            if(entity is null)
            {
                return false;
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                _dbContext.ChangeTracker.Clear();
                throw;
            }
        }

        protected IQueryable<TEntity> Sort(IQueryable<TEntity> query)
        {
            if(query is IQueryable<ICreateble>)
            {
                return query.OrderByDescending(e => (e as ICreateble).Created);
            }

            return query;
        }
        #endregion
    }
}
