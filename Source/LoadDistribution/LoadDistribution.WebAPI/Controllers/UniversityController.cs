using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class UniversityController : ProjectRelatedCollectionController<UniversityDTO>
    {
        #region Constructors
        public UniversityController(IUniversityFacade universityFacade) : base(universityFacade)
        {
        }
        #endregion
    }
}
