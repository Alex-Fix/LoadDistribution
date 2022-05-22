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
      public abstract class ProjectRelatedCollectionController<TEntity, TDTO> : Controller<TEntity, TDTO>
        where TEntity : class, IProjectRelatedEntity
        where TDTO : class, IProjectRelatedDTO
      {
            #region Constructors
            public ProjectRelatedCollectionController(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
            {
            }
            #endregion

            #region Methods
            [HttpGet("All")]
            public virtual async Task<IActionResult> GetAll(int projectId)
            {
                  IList<TEntity> entities;
                  if (typeof(TEntity).IsAssignableTo(typeof(ICreateble)))
                  {
                        entities = await _repository.ListAsync(sortExpression: entity => (entity as ICreateble).Created, filterExpression: entity => entity.ProjectId == projectId);
                  }
                  else
                  {
                        entities = await _repository.ListAsync();
                  }

                  IList<TDTO> dtos = _mapper.Map<IList<TDTO>>(entities);

                  return Ok(dtos);
            }

            [HttpGet("Paged")]
            public virtual async Task<IActionResult> GetPaged(int projectId, int pageNumber, int pageSize)
            {
                  Paged<TEntity> entities;
                  if (typeof(TEntity).IsAssignableTo(typeof(ICreateble)))
                  {
                        entities = await _repository.PagedAsync(pageNumber, pageSize, sortExpression: entity => (entity as ICreateble).Created, filterExpression: entity => entity.ProjectId == projectId);
                  }
                  else
                  {
                        entities = await _repository.PagedAsync(pageNumber, pageSize, filterExpression: entity => entity.ProjectId == projectId);
                  }

                  Paged<TDTO> dtos = _mapper.Map<Paged<TDTO>>(entities);

                  return Ok(dtos);
            }
            #endregion
      }
}
