using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LecturerController : ProjectRelatedCollectionController<Lecturer, LecturerDTO>
    {
        #region Constructors
        public LecturerController(IProjectRelatedCollectionFacade<Lecturer, LecturerDTO> lecturerFacade) : base(lecturerFacade)
        {
        }
        #endregion
    }
}
