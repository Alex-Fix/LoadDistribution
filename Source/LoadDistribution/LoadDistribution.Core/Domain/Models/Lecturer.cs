using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models;

public class Lecturer : BaseProjectRelatedEntity
{
      public string FirstName { get; set; } = string.Empty;
      public string MiddleName { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;

      // navigation properties
      public virtual ICollection<UniversityLecturerMap>? UniversityLecturerMaps { get; set; }
      public virtual ICollection<LecturerDisciplineActivityMap>? LecturerDisciplineActivityMaps { get; set; }
}
