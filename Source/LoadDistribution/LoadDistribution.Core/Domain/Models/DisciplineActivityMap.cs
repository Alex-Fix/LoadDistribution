namespace LoadDistribution.Core.Domain.Models
{
      public class DisciplineActivityMap : BaseProjectRelatedEntity
      {
            public int DisciplineId { get; set; }
            public int ActivityId { get; set; }
            public double Value { get; set; }

            // navigation properties
            public virtual Discipline? Discipline { get; set; }
            public virtual Activity? Activity { get; set; }
      }
}
