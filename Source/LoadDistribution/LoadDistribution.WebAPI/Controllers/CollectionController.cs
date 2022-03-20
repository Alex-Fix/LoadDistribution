using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers
{
    public abstract class CollectionController<TDTO> : Controller<TDTO> where TDTO : class, IDTO
    {
        #region Fields
        private readonly ICollectionFacade<TDTO> _collectionFacade;
        #endregion

        #region Constructors
        public CollectionController(ICollectionFacade<TDTO> collectionFacade) : base(collectionFacade)
        {
            _collectionFacade = collectionFacade ?? throw new ArgumentNullException(nameof(collectionFacade));
        }
        #endregion

        #region Methods
        [HttpGet("All")]
        public virtual async Task<IActionResult> GetAll()
        {
            IList<TDTO> entities = await _collectionFacade.GetAll();
            return Ok(entities);
        }

        [HttpGet("Paged")]
        public virtual async Task<IActionResult> GetPaged(int pageNumber, int pageSize)
        {
            Paged<TDTO> entities = await _collectionFacade.GetPaged(pageNumber, pageSize);
            return Ok(entities);
        }
        #endregion
    }
}
