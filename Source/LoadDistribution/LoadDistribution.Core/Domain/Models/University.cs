using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class University : BaseProjectRelatedEntity
    {
        public string Name { get; set; }

        // navigation properties
        public virtual ICollection<UniversityLecturerMap> UniversityLecturerMaps { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
