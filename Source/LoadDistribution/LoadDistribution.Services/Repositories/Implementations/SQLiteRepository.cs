using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations
{
    public abstract class SQLiteRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        #region Fields
        protected readonly TContext _dbContext;
        #endregion

        #region Constructors
        public SQLiteRepository(TContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion

        #region Methods
        public async virtual Task<TEntity> Get(int id)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<InsertResult> Insert(TEntity entity, bool excludeNested = false)
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
            if(excludeNested && entity is INavigationCleanable navigationCleanable)
            {
                navigationCleanable.CleanNavigationProperties();
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.AddAsync(entity);
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

        public async virtual Task<bool> Update(TEntity entity, bool excludeNested = false)
        {
            if(entity is null)
            {
                return false;
            }

            if(entity is IUpdateble updateble)
            {
                updateble.Updated = DateTimeOffset.UtcNow;
            }
            if (excludeNested && entity is INavigationCleanable navigationCleanable)
            {
                navigationCleanable.CleanNavigationProperties();
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _dbContext.Update(entity);
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
                _dbContext.Remove(entity);
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
