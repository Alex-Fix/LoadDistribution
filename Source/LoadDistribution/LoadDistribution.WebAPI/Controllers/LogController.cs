using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers;

public class LogController : CollectionController<Log, LogDTO>
{
      #region Constructors
      public LogController(IRepository<Log> repository, IMapper mapper) : base(repository, mapper)
      {
      }
      #endregion
}
