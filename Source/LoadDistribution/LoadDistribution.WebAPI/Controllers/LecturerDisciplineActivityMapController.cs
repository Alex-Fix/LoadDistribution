using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LecturerDisciplineActivityMapController : ProjectRelatedCollectionController<LecturerDisciplineActivityMap, LecturerDisciplineActivityMapDTO>
    {
        #region Constructors
        public LecturerDisciplineActivityMapController(IProjectRelatedCollectionFacade<LecturerDisciplineActivityMap, LecturerDisciplineActivityMapDTO> lecturerDisciplineActivityMapFacade) : base(lecturerDisciplineActivityMapFacade)
        {
        }
        #endregion
    }
}
