using System;

namespace LoadDistribution.Core.Domain.Interfaces
{
    public interface ICreateble
    {
        public DateTimeOffset Created { get; set; }
    }
}
