using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class UniversityLecturerMapController : ProjectRelatedCollectionController<UniversityLecturerMapDTO>
    {
        #region Constructors
        public UniversityLecturerMapController(IUniversityLecturerMapFacade universityLecturerMapFacade) : base(universityLecturerMapFacade)
        {
        }
        #endregion
    }
}
