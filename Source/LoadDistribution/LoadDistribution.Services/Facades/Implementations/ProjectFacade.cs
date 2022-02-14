using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class ProjectFacade : BaseFacade<Project, ProjectDTO>, IProjectFacade
    {
        #region Fields
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProjectFacade(IProjectRepository projectRepository, IMapper mapper) : base(projectRepository, mapper)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
    }
}
