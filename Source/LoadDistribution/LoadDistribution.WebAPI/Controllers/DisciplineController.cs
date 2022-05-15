using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers
{
    public class DisciplineController : ProjectRelatedCollectionController<Discipline, DisciplineDTO>
    {
        #region Constructors
        public DisciplineController(IRepository<Discipline> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        #endregion
    }
}
