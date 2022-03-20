using LoadDistribution.Core.Domain.Interfaces;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}
