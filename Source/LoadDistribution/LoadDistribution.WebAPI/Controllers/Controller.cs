using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class Controller<TEntity, TDTO> : ControllerBase 
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        #region Fields
        private readonly IFacade<TEntity, TDTO> _facade;
        #endregion

        #region Constructors
        public Controller(IFacade<TEntity, TDTO> facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }
        #endregion

        #region Methods
        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            TDTO entity = await _facade.Get(id);
            if(entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TDTO entity)
        {
            InsertResult result = await _facade.Insert(entity);
            if(result.Success)
            {
                return Ok(result);
            }   

            return UnprocessableEntity();
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TDTO entity)
        {
            bool updated = await _facade.Update(entity);
            if(updated)
            {
                return Ok();
            }

            return UnprocessableEntity();
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _facade.Delete(id);
            if (deleted)
            {
                return Ok();
            }

            return UnprocessableEntity();
        }
        #endregion
    }
}
