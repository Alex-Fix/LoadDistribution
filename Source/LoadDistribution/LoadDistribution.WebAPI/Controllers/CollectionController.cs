using AutoMapper;
using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers.Models;
using LoadDistribution.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers
{
    public abstract class CollectionController<TEntity, TDTO> : Controller<TEntity, TDTO>
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        #region Constructors
        public CollectionController(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        #endregion

        #region Methods
        [HttpGet("All")]
        public virtual async Task<IActionResult> GetAll()
        {
            IList<TEntity> entities;
            if (typeof(TEntity) is ICreateble)
            {
                entities = await _repository.ListAsync(sortExpression: entity => (entity as ICreateble).Created);
            }
            else
            {
                entities = await _repository.ListAsync();
            }

            IList<TDTO> dtos = _mapper.Map<IList<TDTO>>(entities);

            return Ok(dtos);
        }

        [HttpGet("Paged")]
        public virtual async Task<IActionResult> GetPaged([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            Paged<TEntity> entities;
            if (typeof(TEntity) is ICreateble)
            {
                entities = await _repository.PagedAsync(pageNumber, pageSize, sortExpression: entity => (entity as ICreateble).Created);
            }
            else
            {
                entities = await _repository.PagedAsync(pageNumber, pageSize);
            }

            Paged<TDTO> dtos = _mapper.Map<Paged<TDTO>>(entities);

            return Ok(dtos);
        }
        #endregion
    }
}
