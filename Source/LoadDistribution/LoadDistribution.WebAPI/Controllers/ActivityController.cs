using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ActivityController : ProjectRelatedCollectionController<Activity, ActivityDTO>
    {
        #region Constructors
        public ActivityController(IProjectRelatedCollectionFacade<Activity, ActivityDTO> activityFacade) : base(activityFacade)
        {
        }
        #endregion
    }
}
