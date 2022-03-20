using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class DisciplineFacade : ProjectRelatedCollectionFacade<Discipline, DisciplineDTO>, IDisciplineFacade
    {
        #region Constructors
        public DisciplineFacade(IDisciplineRepository disciplineRepository, IMapper mapper) : base(disciplineRepository, mapper)
        {
        }
        #endregion
    }
}
