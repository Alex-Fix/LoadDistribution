using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Repositories;
using System;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class ActivityFacade : BaseFacade<Activity, ActivityDTO>, IActivityFacade
    {
        #region Fields
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ActivityFacade(IActivityRepository activityRepository, IMapper mapper) : base(activityRepository, mapper)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion
    }
}
