using LoadDistribution.Core.Domain.Enums;
using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Discipline : BaseProjectRelatedEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Term { get; set; }
        public string EducationLevel { get; set; }
        public string EducationForm { get; set; }
        public string PlanIndex { get; set; }
        public string Speciality { get; set; }
        public string GroupAbbreviation { get; set; }
        public string Specialization { get; set; }
        public string Institute { get; set; }
        public int Course { get; set; }
        public int StudentCount { get; set; }
        public int BudgetStudentCount { get; set; }
        public int ComercialStudentCount { get; set; }
        public int GroupCount { get; set; }
        public int SubgroupCount { get; set; }
        public int ThreadCount { get; set; }
        public int UniversityId { get; set; }

        // navigation properties
        public virtual University University { get; set; }
        public virtual ICollection<DisciplineActivityMap> DisciplineActivityMaps { get; set; }
    }
}
