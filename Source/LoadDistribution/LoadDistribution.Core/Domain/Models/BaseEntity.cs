using System;

namespace LoadDistribution.Core.Domain.Models
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
