using LoadDistribution.Core.Domain.Enums;

namespace LoadDistribution.Core.DTO.Models;

public class ActivityDTO : BaseProjectRelatedDTO
{
      public string Name { get; set; } = string.Empty;
      public DependencyType DependencyType { get; set; }
}
