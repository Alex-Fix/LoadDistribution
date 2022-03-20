using LoadDistribution.Core.DTO.Interfaces;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades
{
    public interface IFacade<TDTO> where TDTO : class, IDTO
    {
        Task<TDTO> Get(int id);
        Task<TDTO> Insert(TDTO entity);
        Task<TDTO> Update(TDTO entity);
        Task<TDTO> Delete(int id);
    }
}
