﻿using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades
{
    public interface IFacade<TDTO> where TDTO : class, IDTO
    {
        Task<IList<TDTO>> GetAll();
        Task<TDTO> Get(int id);
        Task<Paged<TDTO>> GetPaged(int pageNumber, int pageSize);
        Task<TDTO> Insert(TDTO entity);
        Task<TDTO> Update(TDTO entity);
        Task<TDTO> Delete(int id);
    }
}
