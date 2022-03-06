using System;

namespace LoadDistribution.Core.DTO
{
    public abstract class BaseDTO : IDTO
    {
        public int Id { get; set; } 
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
