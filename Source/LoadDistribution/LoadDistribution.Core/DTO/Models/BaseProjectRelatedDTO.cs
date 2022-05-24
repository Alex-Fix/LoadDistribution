using LoadDistribution.Core.DTO.Interfaces;

namespace LoadDistribution.Core.DTO.Models;

public abstract class BaseProjectRelatedDTO : BaseDTO, IProjectRelatedDTO
{
      public int ProjectId { get; set; }
}
