using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Facades;
using System;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ProjectController : BaseController<ProjectDTO>
    {
        #region Fields
        private readonly IProjectFacade _projectFacade;
        #endregion

        #region Constructors
        public ProjectController(IProjectFacade projectFacade) : base(projectFacade)
        {
            _projectFacade = projectFacade ?? throw new ArgumentNullException(nameof(projectFacade));
        }
        #endregion
    }
}
