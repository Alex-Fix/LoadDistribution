using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class University : BaseEntity
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }

        // navigation properties
        public virtual Project Project { get; set; }
        public virtual ICollection<UniversityLecturerMap> UniversityLectureMaps { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
