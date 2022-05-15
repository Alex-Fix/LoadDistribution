using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.WebAPI.Controllers
{
    public class UniversityController : ProjectRelatedCollectionController<University, UniversityDTO>
    {
        #region Constructors
        public UniversityController(IRepository<University> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        #endregion
    }
}
