using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class DisciplineController : ProjectRelatedCollectionController<DisciplineDTO>
    {
        #region Constructors
        public DisciplineController(IDisciplineFacade disciplineFacade) : base(disciplineFacade)
        {
        }
        #endregion
    }
}
