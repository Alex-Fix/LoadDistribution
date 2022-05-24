using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers;

public class LecturerDisciplineActivityMapController : ProjectRelatedCollectionController<LecturerDisciplineActivityMap, LecturerDisciplineActivityMapDTO>
{
      #region Constructors
      public LecturerDisciplineActivityMapController(IRepository<LecturerDisciplineActivityMap> repository, IMapper mapper) : base(repository, mapper)
      {
      }
      #endregion
}
