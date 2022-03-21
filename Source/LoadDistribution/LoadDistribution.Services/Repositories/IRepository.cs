using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        Task<TEntity> Get(int id);
        Task<InsertResult> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}
