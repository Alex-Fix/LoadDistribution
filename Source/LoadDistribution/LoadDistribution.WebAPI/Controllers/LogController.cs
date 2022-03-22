using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Facades;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LogController : CollectionController<Log, LogDTO>
    {
        #region Constructors
        public LogController(ICollectionFacade<Log, LogDTO> logFacade) : base(logFacade)
        {
        }
        #endregion
    }
}
