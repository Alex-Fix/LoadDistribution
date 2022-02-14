using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }

        // navigation properties
        public virtual ICollection<DisciplineActivityMap> DisciplineActivityMaps { get; set; }
    }
}
