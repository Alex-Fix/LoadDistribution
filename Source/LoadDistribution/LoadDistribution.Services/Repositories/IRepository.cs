using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers.Enums;
using LoadDistribution.Core.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
      Task<TEntity?> GetAsync(int id);
      Task<InsertResult> InsertAsync(TEntity entity);
      Task<BulkInsertResult> InsertAsync(IEnumerable<TEntity> entities);
      Task<bool> UpdateAsync(TEntity entity);
      Task<bool> UpdateAsync(IEnumerable<TEntity> entities);
      Task<bool> DeleteAsync(int id);
      Task<IList<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? filterExpression = null);
      Task<IList<TEntity>> ListAsync<TKey>(Expression<Func<TEntity, TKey>> sortExpression, AscDesc ascDesc = AscDesc.Desc, Expression<Func<TEntity, bool>>? filterExpression = null);
      Task<Paged<TEntity>> PagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>>? filterExpression = null);
      Task<Paged<TEntity>> PagedAsync<TKey>(int pageNumber, int pageSize, Expression<Func<TEntity, TKey>> sortExpression, AscDesc ascDesc = AscDesc.Desc, Expression<Func<TEntity, bool>>? filterExpression = null);
}
