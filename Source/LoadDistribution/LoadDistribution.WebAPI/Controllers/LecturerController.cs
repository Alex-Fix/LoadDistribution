using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers;

public class LecturerController : ProjectRelatedCollectionController<Lecturer, LecturerDTO>
{
      #region Constructors
      public LecturerController(IRepository<Lecturer> repository, IMapper mapper) : base(repository, mapper)
      {
      }
      #endregion
}
