using System;

namespace LoadDistribution.Core.Domain.Interfaces;

public interface IUpdateble
{
      public DateTimeOffset Updated { get; set; }
}
