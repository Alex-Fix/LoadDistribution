namespace LoadDistribution.Core.Domain.Models
{
    public class LecturerDisciplineActivityMap : BaseProjectRelatedEntity
    {
        public int LecturerId { get; set; }
        public int DisciplineId { get; set; }
        public int ActivityId { get; set; }
        public decimal Rate { get; set; }

        // navigation properties
        public virtual Lecturer Lecturer { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
