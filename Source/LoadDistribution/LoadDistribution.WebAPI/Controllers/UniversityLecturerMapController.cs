using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO.Models;
using LoadDistribution.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Controllers;

public class UniversityLecturerMapController : ProjectRelatedCollectionController<UniversityLecturerMap, UniversityLecturerMapDTO>
{
      #region Constructors
      public UniversityLecturerMapController(IRepository<UniversityLecturerMap> repository, IMapper mapper) : base(repository, mapper)
      {
      }
      #endregion

      #region Methods
      [HttpGet("Search")]
      public async Task<IActionResult> SearchAsync([FromQuery] int? lecturerId)
      {
            IList<UniversityLecturerMap> entities = await _repository.ListAsync(
                sortExpression: ulp => ulp.Created,
                filterExpression: ulp => (lecturerId == null || ulp.LecturerId == lecturerId.Value)
                                        //TODO: implement other filters
                                        );

            IList<UniversityLecturerMapDTO> dtos = _mapper.Map<IList<UniversityLecturerMapDTO>>(entities);

            return Ok(dtos);
      }
      #endregion
}
