using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models;

public class Discipline : BaseProjectRelatedEntity
{
      public string Name { get; set; } = string.Empty;
      public string? Type { get; set; }
      public int Term { get; set; }
      public string? EducationLevel { get; set; }
      public string EducationForm { get; set; } = string.Empty;
      public string PlanIndex { get; set; } = string.Empty;
      public string Speciality { get; set; } = string.Empty;
      public string GroupAbbreviation { get; set; } = string.Empty;
      public string Specialization { get; set; } = string.Empty;
      public string? Institute { get; set; }
      public int Course { get; set; }
      public int StudentCount { get; set; }
      public int BudgetStudentCount { get; set; }
      public int ComercialStudentCount { get; set; }
      public int GroupCount { get; set; }
      public int SubgroupCount { get; set; }
      public int ThreadCount { get; set; }
      public int UniversityId { get; set; }

      // navigation properties
      public virtual University? University { get; set; }
      public virtual ICollection<LecturerDisciplineActivityMap>? LecturerDisciplineActivityMaps { get; set; }
}
