using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class LogFacade : CollectionFacade<Log, LogDTO>, ILogFacade
    {
        #region Constructors
        public LogFacade(ILogRepository logRepository, IMapper mapper) : base(logRepository, mapper)
        {
        }
        #endregion
    }
}
