using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class UniversityController : ProjectRelatedCollectionController<University, UniversityDTO>
    {
        #region Constructors
        public UniversityController(IProjectRelatedCollectionFacade<University, UniversityDTO> universityFacade) : base(universityFacade)
        {
        }
        #endregion
    }
}
