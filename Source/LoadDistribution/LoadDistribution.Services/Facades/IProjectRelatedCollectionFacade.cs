using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades
{
    public interface IProjectRelatedCollectionFacade<TEntity, TDTO> : IFacade<TEntity, TDTO> 
        where TEntity : class, IProjectRelatedEntity
        where TDTO : class, IProjectRelatedDTO
    {
        Task<IList<TDTO>> GetAll(int projectId);
        Task<Paged<TDTO>> GetPaged(int projectId, int pageNumber, int pageSize);
    }
}
