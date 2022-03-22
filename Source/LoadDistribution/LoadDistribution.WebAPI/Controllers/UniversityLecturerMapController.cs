using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class UniversityLecturerMapController : ProjectRelatedCollectionController<UniversityLecturerMap, UniversityLecturerMapDTO>
    {
        #region Constructors
        public UniversityLecturerMapController(IProjectRelatedCollectionFacade<UniversityLecturerMap, UniversityLecturerMapDTO> universityLecturerMapFacade) : base(universityLecturerMapFacade)
        {
        }
        #endregion
    }
}
