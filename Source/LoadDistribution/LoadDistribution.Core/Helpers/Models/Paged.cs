using System.Collections.Generic;

namespace LoadDistribution.Core.Helpers.Models;

public class Paged<TEntity>
{
      public int PageNumber { get; set; }
      public int PageSize { get; set; }
      public int PageCount { get; set; }
      public int TotalCount { get; set; }
      public List<TEntity> List { get; set; } = new List<TEntity>();
}
