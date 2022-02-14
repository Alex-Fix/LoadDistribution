using System;

namespace LoadDistribution.Core.DTO
{
    public abstract class BaseDTO : IDTO
    {
        public int Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
    }
}
