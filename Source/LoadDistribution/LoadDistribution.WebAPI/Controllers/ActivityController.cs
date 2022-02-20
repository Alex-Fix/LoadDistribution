using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Facades;
using System;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ActivityController : ProjectRelatedCollectionController<ActivityDTO>
    {
        #region Fields
        private readonly IActivityFacade _activityFacade;
        #endregion

        #region Constructors
        public ActivityController(IActivityFacade activityFacade) : base(activityFacade)
        {
            _activityFacade = activityFacade ?? throw new ArgumentNullException(nameof(activityFacade));
        }
        #endregion
    }
}
