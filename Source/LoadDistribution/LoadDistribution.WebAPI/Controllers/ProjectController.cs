using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers;

public class ProjectController : CollectionController<Project, ProjectDTO>
{
      #region Constructors
      public ProjectController(IRepository<Project> repository, IMapper mapper) : base(repository, mapper)
      {
      }
      #endregion
}
