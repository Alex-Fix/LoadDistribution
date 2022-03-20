using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ActivityController : ProjectRelatedCollectionController<ActivityDTO>
    {
        #region Constructors
        public ActivityController(IActivityFacade activityFacade) : base(activityFacade)
        {
        }
        #endregion
    }
}
