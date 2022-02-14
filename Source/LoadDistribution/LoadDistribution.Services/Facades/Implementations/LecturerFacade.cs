using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class LecturerFacade : BaseFacade<Lecturer, LecturerDTO>, ILecturerFacade
    {
        #region Fields
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public LecturerFacade(ILecturerRepository lecturerRepository, IMapper mapper) : base(lecturerRepository, mapper)
        {
            _lecturerRepository = lecturerRepository ?? throw new ArgumentNullException(nameof(lecturerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
    }
}
