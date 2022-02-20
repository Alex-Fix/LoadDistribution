using LoadDistribution.Core.DTO;
using LoadDistribution.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades
{
    public interface ICollectionFacade<TDTO> : IFacade<TDTO> where TDTO : class, IDTO
    {
        Task<IList<TDTO>> GetAll();
        Task<Paged<TDTO>> GetPaged(int pageNumber, int pageSize);
    }
}
