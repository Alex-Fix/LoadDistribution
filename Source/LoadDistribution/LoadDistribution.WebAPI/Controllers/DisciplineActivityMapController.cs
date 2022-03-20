using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class DisciplineActivityMapController : ProjectRelatedCollectionController<DisciplineActivityMapDTO>
    {
        #region Constructors
        public DisciplineActivityMapController(IDisciplineActivityMapFacade disciplineActivityMapFacade) : base(disciplineActivityMapFacade)
        {
        }
        #endregion
    }
}
