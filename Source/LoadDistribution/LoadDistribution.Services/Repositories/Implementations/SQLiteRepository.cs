﻿using LoadDistribution.Core.Domain.Models;
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

        public async virtual Task<TEntity> Insert(TEntity entity)
        {
            if(entity is null)
            {
                return null;
            }

            if(entity is BaseEntity baseEntity)
            {
                baseEntity.Created = DateTimeOffset.UtcNow;
                baseEntity.Updated = DateTimeOffset.UtcNow;
            }

            EntityEntry<TEntity> entry = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            if(entity is null)
            {
                return null;
            }

            if (entity is BaseEntity baseEntity)
            {
                baseEntity.Updated = DateTimeOffset.UtcNow;
            }

            EntityEntry<TEntity> entry = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async virtual Task<TEntity> Delete(int id)
        {
            var entity = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
            if(entity is null)
            {
                return null;
            }

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        protected IQueryable<TEntity> Sort(IQueryable<TEntity> query)
        {
            if(query is IQueryable<BaseEntity>)
            {
                return query.OrderByDescending(e => (e as BaseEntity).Created);
            }

            return query;
        }
        #endregion
    }
}