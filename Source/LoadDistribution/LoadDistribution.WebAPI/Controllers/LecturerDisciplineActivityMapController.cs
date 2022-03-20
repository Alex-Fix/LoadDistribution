using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LecturerDisciplineActivityMapController : ProjectRelatedCollectionController<LecturerDisciplineActivityMapDTO>
    {
        #region Constructors
        public LecturerDisciplineActivityMapController(ILecturerDisciplineActivityMapFacade lecturerDisciplineActivityMapFacade) : base(lecturerDisciplineActivityMapFacade)
        {
        }
        #endregion
    }
}
