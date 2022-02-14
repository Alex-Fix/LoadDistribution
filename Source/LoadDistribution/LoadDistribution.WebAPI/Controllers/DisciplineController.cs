using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Facades;
using System;

namespace LoadDistribution.WebAPI.Controllers
{
    public class DisciplineController : BaseController<DisciplineDTO>
    {
        #region Fields
        private readonly IDisciplineFacade _disciplineFacade;
        #endregion

        #region Constructors
        public DisciplineController(IDisciplineFacade disciplineFacade) : base(disciplineFacade)
        {
            _disciplineFacade = disciplineFacade ?? throw new ArgumentNullException(nameof(disciplineFacade));
        }
        #endregion
    }
}
