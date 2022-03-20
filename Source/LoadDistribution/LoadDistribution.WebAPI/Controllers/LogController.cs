using LoadDistribution.Core.DTO;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LogController : CollectionController<LogDTO>
    {
        #region Constructors
        public LogController(ILogFacade logFacade) : base(logFacade)
        {
        }
        #endregion
    }
}
