using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class UniversityLecturerMapFacade : ProjectRelatedCollectionFacade<UniversityLecturerMap, UniversityLecturerMapDTO>, IUniversityLecturerMapFacade
    {
        #region Constructors
        public UniversityLecturerMapFacade(IUniversityLecturerMapRepository universityLecturerMapRepository, IMapper mapper) : base(universityLecturerMapRepository, mapper)
        {
        }
        #endregion
    }
}
