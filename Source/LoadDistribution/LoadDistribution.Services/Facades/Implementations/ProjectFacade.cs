using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class ProjectFacade : CollectionFacade<Project, ProjectDTO>, IProjectFacade
    {
        #region Fields
        private readonly IProjectRepository _projectRepository;
        #endregion

        #region Constructors
        public ProjectFacade(IProjectRepository projectRepository, IMapper mapper) : base(projectRepository, mapper)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }
        #endregion
    }
}
