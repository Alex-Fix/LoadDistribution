using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LecturerController : ProjectRelatedCollectionController<LecturerDTO>
    {
        #region Constructors
        public LecturerController(ILecturerFacade lecturerFacade) : base(lecturerFacade)
        {
        }
        #endregion
    }
}
