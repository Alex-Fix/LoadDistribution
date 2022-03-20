using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class ActivityFacade : ProjectRelatedCollectionFacade<Activity, ActivityDTO>, IActivityFacade
    {
        #region Constructors
        public ActivityFacade(IActivityRepository activityRepository, IMapper mapper) : base(activityRepository, mapper)
        {
        }
        #endregion
    }
}
