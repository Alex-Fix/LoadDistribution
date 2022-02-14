using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class UniversityFacade : BaseFacade<University, UniversityDTO>, IUniversityFacade
    {
        #region Fields
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public UniversityFacade(IUniversityRepository universityRepository, IMapper mapper) : base(universityRepository, mapper)
        {
            _universityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
    }
}
