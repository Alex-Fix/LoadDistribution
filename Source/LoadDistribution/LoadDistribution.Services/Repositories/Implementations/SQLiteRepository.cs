using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers.Enums;
using LoadDistribution.Core.Helpers.Models;
using LoadDistribution.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories.Implementations;

public class SQLiteRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
      #region Fields
      protected readonly IDbContext _dbContext;
      #endregion

      #region Constructors
      public SQLiteRepository(IDbContext dbContext)
      {
            _dbContext = dbContext;
      }
      #endregion

      #region Methods
      public async virtual Task<TEntity?> GetAsync(int id)
      {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
      }

      public async virtual Task<InsertResult> InsertAsync(TEntity entity)
      {
            if (entity is null)
            {
                  return new InsertResult(null, false);
            }

            if (entity is ICreateble creatable)
            {
                  creatable.Created = DateTimeOffset.UtcNow;
            }
            if (entity is IUpdateble updateble)
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

      public async virtual Task<BulkInsertResult> InsertAsync(IEnumerable<TEntity> entities)
      {
            if (entities is null)
            {
                  return new BulkInsertResult(null, false);
            }

            foreach (TEntity entity in entities)
            {
                  if (entity is ICreateble creatable)
                  {
                        creatable.Created = DateTimeOffset.UtcNow;
                  }
                  if (entity is IUpdateble updateble)
                  {
                        updateble.Updated = DateTimeOffset.UtcNow;
                  }
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                  await _dbContext.Set<TEntity>().AddRangeAsync(entities);
                  await _dbContext.SaveChangesAsync();
                  await transaction.CommitAsync();

                  return new BulkInsertResult(entities.Select(e => e.Id).ToList(), true);
            }
            catch
            {
                  await transaction.RollbackAsync();
                  _dbContext.ChangeTracker.Clear();
                  throw;
            }
      }

      public async virtual Task<bool> UpdateAsync(TEntity entity)
      {
            if (entity is null)
            {
                  return false;
            }

            if (entity is IUpdateble updateble)
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

      public async virtual Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
      {
            if (entities is null)
            {
                  return false;
            }

            foreach (TEntity entity in entities)
            {
                  if (entity is IUpdateble updateble)
                  {
                        updateble.Updated = DateTimeOffset.UtcNow;
                  }
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                  _dbContext.Set<TEntity>().UpdateRange(entities);
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

      public async virtual Task<bool> DeleteAsync(int id)
      {
            var entity = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
            if (entity is null)
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

      public async virtual Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? filterExpression = null)
      {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (filterExpression is not null)
            {
                  query = query.Where(filterExpression);
            }

            return await query.ToListAsync();
      }

      public async virtual Task<IList<TEntity>> ListAsync<TKey>(Expression<Func<TEntity, TKey>> sortExpression, AscDesc ascDesc = AscDesc.Desc, Expression<Func<TEntity, bool>>? filterExpression = null)
      {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (filterExpression is not null)
            {
                  query = query.Where(filterExpression);
            }

            query = ascDesc switch
            {
                  AscDesc.Asc => query.OrderBy(sortExpression),
                  AscDesc.Desc => query.OrderByDescending(sortExpression),
                  _ => throw new NotImplementedException()
            };

            return await query.ToListAsync();
      }

      public async virtual Task<Paged<TEntity>> PagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>>? filterExpression = null)
      {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (filterExpression is not null)
            {
                  query = query.Where(filterExpression);
            }

            int totalCount = await query.CountAsync();

            query = query.Skip(pageNumber * pageSize);
            query = query.Take(pageSize);

            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);
            List<TEntity> entities = await query.ToListAsync();

            return new Paged<TEntity>
            {
                  PageNumber = pageNumber,
                  PageSize = pageSize,
                  PageCount = pageCount,
                  TotalCount = totalCount,
                  List = entities
            };
      }

      public async virtual Task<Paged<TEntity>> PagedAsync<TKey>(int pageNumber, int pageSize, Expression<Func<TEntity, TKey>> sortExpression, AscDesc ascDesc = AscDesc.Desc, Expression<Func<TEntity, bool>>? filterExpression = null)
      {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (filterExpression is not null)
            {
                  query = query.Where(filterExpression);
            }

            query = ascDesc switch
            {
                  AscDesc.Asc => query.OrderBy(sortExpression),
                  AscDesc.Desc => query.OrderByDescending(sortExpression),
                  _ => throw new NotImplementedException()
            };

            int totalCount = await query.CountAsync();

            query = query.Skip(pageNumber * pageSize);
            query = query.Take(pageSize);

            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);
            List<TEntity> entities = await query.ToListAsync();

            return new Paged<TEntity>
            {
                  PageNumber = pageNumber,
                  PageSize = pageSize,
                  PageCount = pageCount,
                  TotalCount = totalCount,
                  List = entities
            };
      }
      #endregion
}
