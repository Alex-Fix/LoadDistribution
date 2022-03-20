using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ProjectController : CollectionController<ProjectDTO>
    {
        #region Constructors
        public ProjectController(IProjectFacade projectFacade) : base(projectFacade)
        {
        }
        #endregion
    }
}
