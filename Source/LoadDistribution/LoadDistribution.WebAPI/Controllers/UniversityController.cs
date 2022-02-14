using LoadDistribution.Core.DTO;
using LoadDistribution.Services.Facades;
using System;

namespace LoadDistribution.WebAPI.Controllers
{
    public class UniversityController : BaseController<UniversityDTO>
    {
        #region Fields
        private readonly IUniversityFacade _universityFacade;
        #endregion

        #region Constructors
        public UniversityController(IUniversityFacade universityFacade) : base(universityFacade)
        {
            _universityFacade = universityFacade ?? throw new ArgumentNullException(nameof(universityFacade));
        }
        #endregion
    }
}
