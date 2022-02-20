using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Repositories
{
    public interface ICollectionRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IList<TEntity>> GetAll();

        Task<Paged<TEntity>> GetPaged(int pageNumber, int pageSize);
    }
}
