using LoadDistribution.Core.DTO;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TDTO> : ControllerBase where TDTO : class, IDTO
    {
        #region Fields
        private readonly IFacade<TDTO> _facade;
        #endregion

        #region Constructors
        public BaseController(IFacade<TDTO> facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(TDTO));
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IList<TDTO> entity = await _facade.GetAll();
            return Ok(entity);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            TDTO entity = await _facade.Get(id);
            if(entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("Paged")]
        public async Task<IActionResult> Get(int pageNumber, int pageSize)
        {
            Paged<TDTO> entities = await _facade.GetPaged(pageNumber, pageSize);
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TDTO entity)
        {
            TDTO dbEntity = await _facade.Insert(entity);
            if(dbEntity is null)
            {
                return BadRequest();
            }

            return Ok(dbEntity);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TDTO entity)
        {
            TDTO dbEntity = await _facade.Update(entity);
            if(dbEntity is null)
            {
                return BadRequest();
            }

            return Ok(dbEntity);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            TDTO entity = await _facade.Delete(id);
            if(entity is null)
            {
                return BadRequest();
            }

            return Ok(entity);
        }
        #endregion
    }
}
