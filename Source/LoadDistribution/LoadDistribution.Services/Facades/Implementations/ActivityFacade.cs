using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class ActivityFacade : ProjectRelatedCollectionFacade<Activity, ActivityDTO>, IActivityFacade
    {
        #region Fields
        private readonly IActivityRepository _activityRepository;
        #endregion

        #region Constructors
        public ActivityFacade(IActivityRepository activityRepository, IMapper mapper) : base(activityRepository, mapper)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
        }
        #endregion
    }
}
