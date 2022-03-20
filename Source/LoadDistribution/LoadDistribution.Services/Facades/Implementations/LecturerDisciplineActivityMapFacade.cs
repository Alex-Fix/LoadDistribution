using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class LecturerDisciplineActivityMapFacade : ProjectRelatedCollectionFacade<LecturerDisciplineActivityMap, Core.DTO.Models.LecturerDisciplineActivityMapDTO>, ILecturerDisciplineActivityMapFacade
    {
        #region Contructors
        public LecturerDisciplineActivityMapFacade(ILecturerDisciplineActivityMapRepository lecturerDisciplineActivityMapRepository, IMapper mapper) : base(lecturerDisciplineActivityMapRepository, mapper)
        {
        }
        #endregion
    }
}
