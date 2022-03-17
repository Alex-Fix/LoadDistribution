using LoadDistribution.Core.Domain.Enums;
using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Activity : BaseProjectRelatedEntity
    {
        public string Name { get; set; }
        public DependencyType DependencyType { get; set; }

        // navigation properties
        public virtual ICollection<DisciplineActivityMap> DisciplineActivityMaps { get; set; }
    }
}
