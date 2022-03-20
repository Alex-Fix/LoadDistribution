using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class LecturerFacade : ProjectRelatedCollectionFacade<Lecturer, LecturerDTO>, ILecturerFacade
    {
        #region Constructors
        public LecturerFacade(ILecturerRepository lecturerRepository, IMapper mapper) : base(lecturerRepository, mapper)
        {
        }
        #endregion
    }
}
