using System;

namespace LoadDistribution.Core.Domain.Models
{
    public abstract class BaseProjectRelatedEntity : BaseEntity, IProjectRelatedEntity
    {
        public int ProjectId { get; set; }

        // navigation properties
        public virtual Project Project { get; set; }
    }
}
