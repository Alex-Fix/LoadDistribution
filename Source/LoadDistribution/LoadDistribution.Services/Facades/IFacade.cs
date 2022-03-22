using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades
{
    public interface IFacade<TEntity, TDTO>
        where TEntity: class, IEntity
        where TDTO : class, IDTO
    {
        Task<TDTO> Get(int id);
        Task<InsertResult> Insert(TDTO entity);
        Task<bool> Update(TDTO entity);
        Task<bool> Delete(int id);
    }
}
