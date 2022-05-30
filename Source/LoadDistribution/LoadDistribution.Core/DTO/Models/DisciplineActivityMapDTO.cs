namespace LoadDistribution.Core.DTO.Models
{
      public class DisciplineActivityMapDTO : BaseProjectRelatedDTO
      {
            public int DisciplineId { get; set; }
            public int ActivityId { get; set; }
            public double Value { get; set; }
      }
}
