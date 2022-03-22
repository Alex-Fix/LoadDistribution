using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers
{
    public abstract class ProjectRelatedCollectionController<TEntity, TDTO> : Controller<TEntity, TDTO> 
        where TEntity : class, IProjectRelatedEntity
        where TDTO : class, IProjectRelatedDTO
    {
        #region Fields
        private readonly IProjectRelatedCollectionFacade<TEntity, TDTO> _projectRelatedCollectionFacade;
        #endregion

        #region Constructors
        public ProjectRelatedCollectionController(IProjectRelatedCollectionFacade<TEntity, TDTO> projectRelatedCollectionFacade) : base(projectRelatedCollectionFacade)
        {
            _projectRelatedCollectionFacade = projectRelatedCollectionFacade ?? throw new ArgumentNullException(nameof(projectRelatedCollectionFacade));
        }
        #endregion

        #region Methods
        [HttpGet("All")]
        public virtual async Task<IActionResult> GetAll(int projectId)
        {
            IList<TDTO> entities = await _projectRelatedCollectionFacade.GetAll(projectId);
            return Ok(entities);
        }

        [HttpGet("Paged")]
        public virtual async Task<IActionResult> GetPaged(int projectId, int pageNumber, int pageSize)
        {
            Paged<TDTO> entities = await _projectRelatedCollectionFacade.GetPaged(projectId, pageNumber, pageSize);
            return Ok(entities);
        }
        #endregion
    }
}
