using AutoMapper;
using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers.Models;
using LoadDistribution.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        public Controller(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Methods
        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            TEntity entity = await _repository.GetAsync(id);
            if (entity is null)
            {
                return NotFound();
            }

            TDTO dto = _mapper.Map<TDTO>(entity);

            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync([FromBody] TDTO dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            InsertResult result = await _repository.InsertAsync(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return UnprocessableEntity();
        }

        [HttpPost("Bulk")]
        public virtual async Task<IActionResult> PostAsync([FromBody] IEnumerable<TDTO> dtos)
        {
            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(dtos);

            BulkInsertResult result = await _repository.InsertAsync(entities);
            if (result.Success)
            {
                return Ok(result);
            }

            return UnprocessableEntity();
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync([FromBody] TDTO dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            bool updated = await _repository.UpdateAsync(entity);
            if (updated)
            {
                return Ok();
            }

            return UnprocessableEntity();
        }

        [HttpPut("Bulk")]
        public virtual async Task<IActionResult> PutAsync([FromBody] IEnumerable<TDTO> dtos)
        {
            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(dtos);

            bool updated = await _repository.UpdateAsync(entities);
            if (updated)
            {
                return Ok();
            }

            return UnprocessableEntity();
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            bool deleted = await _repository.DeleteAsync(id);
            if (deleted)
            {
                return Ok();
            }

            return UnprocessableEntity();
        }
        #endregion
    }
}
