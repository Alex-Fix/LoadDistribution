using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class DisciplineController : ProjectRelatedCollectionController<Discipline, DisciplineDTO>
    {
        #region Constructors
        public DisciplineController(IProjectRelatedCollectionFacade<Discipline, DisciplineDTO> disciplineFacade) : base(disciplineFacade)
        {
        }
        #endregion
    }
}
