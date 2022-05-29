using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers;

public class LecturerDisciplineActivityMapController : ProjectRelatedCollectionController<LecturerDisciplineActivityMap, LecturerDisciplineActivityMapDTO>
{
      #region Constructors
      public LecturerDisciplineActivityMapController(IRepository<LecturerDisciplineActivityMap> repository, IMapper mapper) : base(repository, mapper)
      {
      }
      #endregion

      #region Methods
      [HttpGet("Search")]
      public async Task<IActionResult> SearchAsync([FromQuery] int? disciplineId)
      {
            IList<LecturerDisciplineActivityMap> entities = await _repository.ListAsync(
                sortExpression: ulp => ulp.Created,
                filterExpression: ulp => (disciplineId == null || ulp.DisciplineId == disciplineId.Value)
                                        //TODO: implement other filters
                                        );

            IList<LecturerDisciplineActivityMapDTO> dtos = _mapper.Map<IList<LecturerDisciplineActivityMapDTO>>(entities);

            return Ok(dtos);
      }
      #endregion
}
