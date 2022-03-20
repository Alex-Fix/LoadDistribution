using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class DisciplineActivityMapFacade : ProjectRelatedCollectionFacade<DisciplineActivityMap, DisciplineActivityMapDTO>, IDisciplineActivityMapFacade
    {
        #region Constructors
        public DisciplineActivityMapFacade(IDisciplineActivityMapRepository disciplineActivityMapRepository, IMapper mapper) : base(disciplineActivityMapRepository, mapper)
        {
        }
        #endregion
    }
}
