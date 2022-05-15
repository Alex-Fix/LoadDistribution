using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers
{
    public class ActivityController : ProjectRelatedCollectionController<Activity, ActivityDTO>
    {
        #region Constructors
        public ActivityController(IRepository<Activity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        #endregion
    }
}
