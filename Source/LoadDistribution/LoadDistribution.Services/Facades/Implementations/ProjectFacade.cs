using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class ProjectFacade : CollectionFacade<Project, ProjectDTO>, IProjectFacade
    {
        #region Constructors
        public ProjectFacade(IProjectRepository projectRepository, IMapper mapper) : base(projectRepository, mapper)
        {
        }
        #endregion
    }
}
