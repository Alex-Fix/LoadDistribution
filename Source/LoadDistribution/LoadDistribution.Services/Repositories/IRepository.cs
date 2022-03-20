using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.Helpers;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        Task<TEntity> Get(int id);
        Task<InsertResult> Insert(TEntity entity, bool excludeNested = false);
        Task<bool> Update(TEntity entity, bool excludeNested = false);
        Task<bool> Delete(int id);
    }
}
