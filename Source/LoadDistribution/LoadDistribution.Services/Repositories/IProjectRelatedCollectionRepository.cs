using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories
{
    public interface IProjectRelatedCollectionRepository<TEntity> : IRepository<TEntity> where TEntity : class, IProjectRelatedEntity
    {
        Task<IList<TEntity>> GetAll(int projectId);

        Task<Paged<TEntity>> GetPaged(int projectId, int pageNumber, int pageSize);
    }
}
