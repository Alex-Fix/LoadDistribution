using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        Task<IList<TEntity>> Get();
        Task<TEntity> Get(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
        Task<Paged<TEntity>> Paged(int pageNumber, int pageSize);
    }
}
