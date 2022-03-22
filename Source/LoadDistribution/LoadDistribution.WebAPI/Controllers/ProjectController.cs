using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ProjectController : CollectionController<Project, ProjectDTO>
    {
        #region Constructors
        public ProjectController(ICollectionFacade<Project, ProjectDTO> projectFacade) : base(projectFacade)
        {
        }
        #endregion
    }
}
