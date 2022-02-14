using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class DisciplineFacade : BaseFacade<Discipline, DisciplineDTO>, IDisciplineFacade
    {
        #region Fields
        private readonly IDisciplineRepository _disciplineRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DisciplineFacade(IDisciplineRepository disciplineRepository, IMapper mapper) : base(disciplineRepository, mapper)
        {
            _disciplineRepository = disciplineRepository ?? throw new ArgumentNullException(nameof(disciplineRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
    }
}
