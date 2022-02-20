using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Facades;
using System;

namespace LoadDistribution.WebAPI.Controllers
{
    public class LecturerController : ProjectRelatedCollectionController<LecturerDTO>
    {
        #region Fields
        private readonly ILecturerFacade _lecturerFacade;
        #endregion

        #region Constructors
        public LecturerController(ILecturerFacade lecturerFacade) : base(lecturerFacade)
        {
            _lecturerFacade = lecturerFacade ?? throw new ArgumentNullException(nameof(lecturerFacade));
        }
        #endregion
    }
}
