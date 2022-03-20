using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class UniversityFacade : ProjectRelatedCollectionFacade<University, UniversityDTO>, IUniversityFacade
    {
        #region Constructors
        public UniversityFacade(IUniversityRepository universityRepository, IMapper mapper) : base(universityRepository, mapper)
        {
        }
        #endregion
    }
}
